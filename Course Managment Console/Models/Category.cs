using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Managment_Console.Models
{
  public class Category
    {
        private static int Count = 0;

        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; private set; }
        public Category(string name,string description)
        {
            
            Name = name;
            Description = description;
            Id = ++Count;
        }
        public override string ToString()
        {
            return $"[{Id}] {Name} - {Description}";
        }
    }
}
