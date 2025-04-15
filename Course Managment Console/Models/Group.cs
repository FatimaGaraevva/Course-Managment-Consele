using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.Generic;

namespace Course_Managment_Console.Models
{
    public class Group
    {
        private string _no;
        private Category _category;

        public string No
        {
            get => _no;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Qrup nömresi boş ve ya null ola bilmez.");
                if (value.Length < 3 || value.Length > 10)
                    throw new ArgumentException("Qrup nömresi 3-10 simvol aralığında olmalıdır.");
                _no = value;
            }
        }

        public bool IsOnline { get; set; }

        public Category Category
        {
            get => _category;
            set
            {
                if (!Enum.IsDefined(typeof(Category), value))
                    throw new ArgumentException("Kateqoriya düzgün teyin edilmeyib.");
                _category = value;
            }
        }

        public int Limit => IsOnline ? 15 : 10;

        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"Qrup: {No} - Kateqoriya: {Category} - {(IsOnline ? "Online" : "Offline")} - Telebe sayı: {Students.Count}/{Limit}";
        }
    }
}
