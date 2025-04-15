using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Managment_Console.Models
{
  public  class ExitHelper
    {
        public static string ReadWithExit(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? null : input;
        }
    }
}
