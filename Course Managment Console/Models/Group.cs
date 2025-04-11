using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Managment_Console.Models
{
   public class Group
    {
        public string No { get; set; }
        public bool IsOnline { get; set; }
        public Category Category { get; set; }
        public int Limit => IsOnline ? 15 : 10;
        public List<Student> Students { get; set; } = new List<Student>();
        
        public override string ToString()
        {
            return $"Qrup: {No} - Kateqoriya: {Category.Name} - {(IsOnline ? "Online" : "Offline")} - Telebe sayı: {Students.Count}/{Limit}";
        }
    }
}
