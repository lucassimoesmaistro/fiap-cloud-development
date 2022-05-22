using System;
using System.Collections.Generic;
using System.Text;

namespace queue_send
{
    class Customer
    {
        public string Id { get; set; }
        public int quantity { get; set; }

        public Customer()
        {
            Id = Guid.NewGuid().ToString();
            Random rnd = new Random();
            quantity = rnd.Next(1000);
        }

        public override string ToString()
        {
            return $"Id : {Id}, Quantity : {quantity}";
        }
    }

    //public class Course
    //{
    //    public Course()
    //    {
    //        Random rnd = new Random();
    //        Id = rnd.Next(1000);
    //        rating = rnd.Next(1000);
    //        Name = "Teste";
    //    }

    //    public override string ToString()
    //    {
    //        return $"Id : {Id}, Quantity : {rating}";
    //    }
    //    public int Id;
    //    public string Name;
    //    public double rating;
    //}
}
