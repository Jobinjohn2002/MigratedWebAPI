module "vpc" {
  source = "./modules/vpc"
  region_name = var.region_name
  vpc_cidr = var.vpc_cidr
  public_subnet_cidr_1 = var.public_subnet_cidr_1
  public_subnet_cidr_2 = var.public_subnet_cidr_2
  private_subnet_cidr = var.private_subnet_cidr
}

module "ecs" {
    source = "./modules/ecs"
    vpc_id = module.vpc.vpc_id
    public_subnet_1_id = module.vpc.public_subnet_id_1   
    public_subnet_2_id = module.vpc.public_subnet_id_2
    private_subnet_id = module.vpc.private_subnet_id
    image = var.image
}
