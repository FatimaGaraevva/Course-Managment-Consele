using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Managment_Console.Models
{
   public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GroupNo { get; set; }
        public string Group { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname} - Qrup: {GroupNo} - {Type}";
        }
    }
}

