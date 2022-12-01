resource "azurerm_resource_group" "webapp_resource_group" {
  name     = "${var.resource_group_name}"
  location = var.location
}

resource "azurerm_service_plan" "webapp_service_plan" {
  name                = "servplanfiap"
  resource_group_name = azurerm_resource_group.webapp_resource_group.name
  location            = azurerm_resource_group.webapp_resource_group.location
  sku_name            = "B1"
  os_type             = "Windows"
}

resource "azurerm_windows_web_app" "webapp_windows" {
  name                = "webappfiapmbalucas"
  resource_group_name = azurerm_resource_group.webapp_resource_group.name
  location            = azurerm_resource_group.webapp_resource_group.location
  service_plan_id     = azurerm_service_plan.webapp_service_plan.id
  site_config {    
    application_stack {
      current_stack = "dotnetcore"
      dotnet_version = "core3.1"
    }
  }
}