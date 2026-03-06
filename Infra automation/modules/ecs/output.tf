output "ecr_repository_url" {
  value = aws_ecr_repository.dev_repo.repository_url
}

output "alb_dns_name" {
  value = aws_lb.ecs_alb.dns_name
}