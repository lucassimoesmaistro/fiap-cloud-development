variable "location" {
  type        = string
  description = "Location of Resources"
  default = "brazilsouth"
}

variable "webapp_name" {
  type        = string
  description = "WebApp Name"
  default = "webappfiapmbalucas"
}

variable "resource_group_name" {
  type        = string
  description = "Resource Group Name"
  default = "grp_fiap"
}