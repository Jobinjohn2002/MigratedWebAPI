terraform {
 backend "s3" {
    bucket       = "exc-ecs-terraform-state" 
    key          = "ecs/terraform"
    region       = "ap-southeast-1"
    use_lockfile = true
    
  }
}