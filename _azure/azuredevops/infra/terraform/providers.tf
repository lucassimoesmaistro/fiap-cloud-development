provider "azurerm" {
    version = "~> 3.0"
    features {}
}

terraform {
    backend "azurerm" {
      resource_group_name = "grp-fiap"   
      storage_account_name = "mbafiapestadoinfra"
      container_name = "terraform"
    }
}

data "azurerm_client_config" "current" {}