using System;
using System.Collections.Generic;
using System.Text;

namespace queue_send
{
    class Order
    {
        public string Id { get; set; }
        public int quantity { get; set; }

        public Order()
        {
            Id = Guid.NewGuid().ToString();
            Random rnd = new Random();
            quantity=rnd.Next(1000);
        }

        public override string ToString()
        {
            return $"Id : {Id}, Quantity : {quantity}";
        }
    }
}
