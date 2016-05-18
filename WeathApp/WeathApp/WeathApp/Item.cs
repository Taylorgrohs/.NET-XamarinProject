using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeathApp
{
    public class Item
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public static List<Item> instances = new List<Item> { };

        public Item()
        {
            Description = "";
            instances.Add(this);
            Id = instances.Count;
              
        }

       
        public static List<Item> GetAll()
        {
            return instances;
        }
    }
}

