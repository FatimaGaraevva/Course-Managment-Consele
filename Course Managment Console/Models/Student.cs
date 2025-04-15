using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Course_Managment_Console.Models
{
    public class Student
    {
        private string _name;
        private string _surname;
        private string _groupNo;
        private string _type;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ad boş ve ya null ola bilmez.");
                _name = value;
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Soyad boş ve ya null ola bilmez.");
                _surname = value;
            }
        }

        public string GroupNo
        {
            get => _groupNo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Qrup nömresi boş ve ya null ola bilməz.");
                _groupNo = value;
            }
        }

        public string Type
        {
            get => _type;
            set
            {
                if (value != "zemanetli" && value != "zemanetsiz")
                    throw new ArgumentException("Tip yalnız 'zemanetli' və ya 'zemanetsiz' ola biler.");
                _type = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} {Surname} - Qrup: {GroupNo} - {Type}";
        }
    }
}
