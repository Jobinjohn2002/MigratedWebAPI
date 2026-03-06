#IAM role
resource "aws_iam_role" "ecs_task_execution_role" {
  name = "ecs_taskexecution_role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [{
      Effect = "Allow"
      Principal = { Service = "ecs-tasks.amazonaws.com" }
      Action = "sts:AssumeRole"
    }]
  })
}

resource "aws_iam_role_policy_attachment" "ecs_exec_policy" {
  role       = aws_iam_role.ecs_task_execution_role.name
  policy_arn = "arn:aws:iam::aws:policy/service-role/AmazonECSTaskExecutionRolePolicy"
}

# security group 
resource "aws_security_group" "alb_sg" {
  name   = "alb-sg"
  vpc_id = var.vpc_id
  ingress {
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }
  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}
resource "aws_security_group" "ecs_sg" {
  vpc_id = var.vpc_id
  ingress {
    from_port       = 80
    to_port         = 80
    protocol        = "tcp"
    security_groups = [aws_security_group.alb_sg.id]
  }
  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

resource "aws_lb" "ecs_alb" {
  name               = "ecs-alb"
#  load_balancer_type = "application"
  subnets            = [var.public_subnet_1_id, var.public_subnet_2_id]
  security_groups    = [aws_security_group.alb_sg.id]
}
resource "aws_lb_target_group" "ecs_tg" {
  name        = "ecs-tg"
  port        = 80
  protocol    = "HTTP"
  vpc_id      = var.vpc_id
  target_type = "ip"

  health_check {
    path = "/"
  }
}
resource "aws_lb_listener" "http" {
  load_balancer_arn = aws_lb.ecs_alb.arn
  port              = 80
  protocol          = "HTTP"

  default_action {
    type             = "forward"
    target_group_arn = aws_lb_target_group.ecs_tg.arn
  }
}

#ECS cluster creation
resource "aws_ecs_cluster" "dev_cluster" {
  name = "ecs-cluster"
}

resource "aws_ecs_task_definition" "webapp" {
  family                   = "webapp"
  requires_compatibilities = ["FARGATE"]
  network_mode             = "awsvpc"
  cpu                      = "512"
  memory                   = "1024"
  execution_role_arn       = aws_iam_role.ecs_task_execution_role.arn

  container_definitions = jsonencode([
    {
      name  = "webapp"
      image = var.image         # need to give ECR URL here
      portMappings = [
        {
          containerPort = 80
            hostPort      = 80
        }
      ]
    }
  ])
}
resource "aws_ecs_service" "app-service" {
  name            = "app-service"
  cluster         = aws_ecs_cluster.dev_cluster.id
  task_definition = aws_ecs_task_definition.webapp.arn
  launch_type     = "FARGATE"
  desired_count   = 1

  network_configuration {
    subnets         = [var.private_subnet_id]
    security_groups = [aws_security_group.ecs_sg.id]
    assign_public_ip = false
  }
    load_balancer {
    target_group_arn = aws_lb_target_group.ecs_tg.arn
    container_name   = "webapp"
    container_port   = 80
  }

  depends_on = [aws_lb_listener.http]
}


# temporarliy creatin ECR here, will move to separate module later
resource "aws_ecr_repository" "dev_repo" {
  name                 = "dev_repo"
  image_tag_mutability = "MUTABLE"
  force_delete         = true 
  image_scanning_configuration {
    scan_on_push = true
  }
}