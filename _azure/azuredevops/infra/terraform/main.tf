module "webapp" {
  source                  = "./modules/webapp"
  name                    = var.webapp_name
  resource_group_name     = var.resource_group_name
  location                = var.location
}
