using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace cosmos_table
{
    class Customer : TableEntity
    {
        public string city { get; set; }
        public Customer()
        {

        }

        public Customer(string p_id,string p_name,string p_city)
        {
            PartitionKey = p_id;
            RowKey = p_name;
            city = p_city;
        }
    }
}
