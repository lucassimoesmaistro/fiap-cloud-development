using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace cosmos_sql
{
    class customer
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; } 
        [JsonProperty(PropertyName = "customerId")]
        public int customerid { get; set; }
        [JsonProperty(PropertyName = "customerName")]
        public string customername { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string city { get; set; }

        public customer(int p_id,string p_name,string p_city)
        {
            customerid = p_id;
            customername = p_name;
            city=p_city;
        }
    }
}
