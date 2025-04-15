using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Managment_Console.Models
{
   public class CoursesService
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public CoursesService()
        {
            Groups.Add(new Group { No = "P101", Category = Category.Programming, IsOnline = true });
            Groups.Add(new Group { No = "D202", Category = Category.Design, IsOnline = false });
            Groups.Add(new Group { No = "S303", Category = Category.SystemAdministration, IsOnline = true });
            AddExistingStudents();
        }

        private void AddExistingStudents()
        {
           
            var group1 = Groups.FirstOrDefault(g => g.No == "P101");
            var group2 = Groups.FirstOrDefault(g => g.No == "D202");

            if (group1 != null)
            {
                group1.Students.Add(new Student { Name = "Fatime", Surname = "Qarayeva", GroupNo = "P101", Type = "zemanetli" });
                group1.Students.Add(new Student { Name = "Lamiye", Surname = "Hesenzade", GroupNo = "P101", Type = "zemanetsiz" });
            }

            if (group2 != null)
            {
                group2.Students.Add(new Student { Name = "Ramil", Surname = "Aslanov", GroupNo = "D202", Type = "zemanetli" });
                group2.Students.Add(new Student { Name = "Aysel", Surname = "Mammadova", GroupNo = "D202", Type = "zemanetsiz" });
            }
        }
         public void ShowAll()
        {
            foreach (var group in Groups)
            {
                Console.WriteLine(group);
            }
        }
        public void EditGroup()
        {
            string oldNo = ExitHelper.ReadWithExit("Deyişmek istediyiniz qrupun nömresini daxil edin (çıkmaq üçün Enter): ");
            if (oldNo == null) return;

            var group = Groups.FirstOrDefault(g => g.No == oldNo);
            if (group == null)
            {
                Console.WriteLine("Qrup tapılmadı.");
                return;
            }

            string newNo = ExitHelper.ReadWithExit("Yeni qrup nömrəsini daxil edin (çıkmaq üçün Enter): ");
            if (newNo == null) return;

            if (Groups.Any(g => g.No == newNo))
            {
                Console.WriteLine("Bu adda başqa qrup mövcuddur.");
                return;
            }

            try
            {
                group.No = newNo;
                foreach (var student in group.Students)
                {
                    student.GroupNo = newNo;
                }
                Console.WriteLine("Qrup nömresi dəyişdirildi.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
            }
        }

        public void ShowGroupsStudents()
        {
            
            string no = ExitHelper.ReadWithExit("Qrup nömresini daxil edin (çıkmaq üçün Enter): ");
            if (no == null) return;

            
            var group = Groups.FirstOrDefault(g => g.No == no);
            if (group == null)
            {
                Console.WriteLine("Qrup tapılmadı.");
                return;
            }

            
            if (group.Students.Count == 0)
            {
                Console.WriteLine("Bu qrupda heç bir telebe yoxdur.");
            }
            else
            {
                Console.WriteLine($"Qrup: {group.No} - Kateqoriya: {group.Category} - {(group.IsOnline ? "Online" : "Offline")}");
                Console.WriteLine("Telebeler:");
                foreach (var student in group.Students)
                {
                    Console.WriteLine(student);
                }
            }
        }

        public void CreatedGroup()
        {
            try
            {
                string no = ExitHelper.ReadWithExit("Qrup nömresini daxil edin (çıkmaq üçün Enter): ");
                if (no == null) return;

                if (Groups.Any(g => g.No == no))
                {
                    Console.WriteLine("Bu adda qrup artıq mövcuddur.");
                    return;
                }

                Console.WriteLine("Kateqoriyalardan birini seçin:");
                foreach (var cat in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)cat}. {cat}");
                }

                string categoryInput = ExitHelper.ReadWithExit("Kateqorinin ID-sini daxil et (çıkmaq üçün Enter): ");
                if (categoryInput == null) return;

                if (!int.TryParse(categoryInput, out int categoryId) || !Enum.IsDefined(typeof(Category), categoryId))
                {
                    Console.WriteLine("Yanlış kateqoriya seçimi.");
                    return;
                }

                string isOnlineInput = ExitHelper.ReadWithExit("Qrup onlinedir? (beli/xeyr) (çıkmaq üçün Enter): ");
                if (isOnlineInput == null) return;

                bool isOnline = isOnlineInput.Trim().ToLower() == "beli";

                Group group = new Group
                {
                    No = no,
                    Category = (Category)categoryId,
                    IsOnline = isOnline
                };

                Groups.Add(group);
                Console.WriteLine("Qrup yaradıldı.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Namelum xeta baş verdi: " + ex.Message);
            }
        }  
        public void ShowAllStudents()
        {
            foreach (var group in Groups)
            {
                foreach (var student in group.Students)
                {
                    Console.WriteLine(student);
                }
            }
        }
        public void CreatedStudent()
        {
            try
            {
                string name = ExitHelper.ReadWithExit("Telebenin adı (çıkmaq üçün Enter): ");
                if (name == null|| name.Length <= 3)
                {
                    Console.WriteLine("Bu ad formati duzgun deyil");

                }

               

                string surname = ExitHelper.ReadWithExit("Telebenin soyadı (çıkmaq üçün Enter): ");
                if (surname == null|| surname.Length<=3)
                {
                    Console.WriteLine("Soyad formadi duzgun deyil");
                }

                string groupNo = ExitHelper.ReadWithExit("Qrup nömresi (çıkmaq üçün Enter): ");
                if (groupNo == null)
                {
                    Console.WriteLine("Qrupun nomresini daxil etmelisiniz");
                }

                var group = Groups.FirstOrDefault(g => g.No == groupNo);
                if (group == null)
                {
                    Console.WriteLine("Qrup tapılmadı.");
                    return;
                }

                if (group.Students.Count >= group.Limit)
                {
                    Console.WriteLine("Qrup doludur.");
                    return;
                }

                string type = ExitHelper.ReadWithExit("Telebe tipi (zemanetli/zemanetsiz) (çıkmaq üçün Enter): ");
                if (type == null) return;

                Student student = new Student
                {
                    Name = name,
                    Surname = surname,
                    GroupNo = groupNo,
                    Type = type
                };

                group.Students.Add(student);
                Console.WriteLine("Telebe elavə edildi.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
            }
        }




    }

}

