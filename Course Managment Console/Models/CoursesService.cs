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
            var programming = new Category("Programming", "Kod və proqram teminatı");
            var design = new Category("Design", "Qrafik dizayn");
            var system = new Category("System Administration", "Şebeke ve sistem idaresi");

            Categories.Add(programming);
            Categories.Add(design);
            Categories.Add(system);

            var group1 = new Group { No = "P101", Category = programming, IsOnline = true };
            var group2 = new Group { No = "D202", Category = design, IsOnline = false };
            var group3 = new Group { No = "S303", Category = system, IsOnline = true };

            group1.Students.Add(new Student { Name = "Fatime", Surname = "Qarayeva", GroupNo = "BB209", Type = "zemanetli" });
            group1.Students.Add(new Student { Name = "Lamiye", Surname = "Hesenzade", GroupNo = "BB208", Type = "zemanetsiz" });

            for (int i = 1; i <= 10; i++)
            {
                group2.Students.Add(new Student
                {
                    Name = $"Student{i}",
                    Surname = "Test",
                    GroupNo = "D202",
                    Type = i % 2 == 0 ? "zemanetli" : "zemanetsiz"
                });
            }

            Groups.Add(group1);
            Groups.Add(group2);
            Groups.Add(group3);
        }
        
       

        public void CreatedGroup()
        {
            Console.WriteLine("Qrupunuzun nomresini  daxil edin");
          string no=Console.ReadLine();
            if (Groups.Any(g=>g.No==no))
            {
                Console.WriteLine("Bu adda qrup movcudur");
                return;
            }
            Console.WriteLine("Kategoryalardan birini secin");
            foreach (var category in Categories)
            {
                Console.WriteLine(category);
                Console.WriteLine("Kategorinin ID daxil et ");
                int categoryId=Convert.ToInt32(Console.ReadLine());
                var selectedCategory = Categories.FirstOrDefault(c => c.Id == categoryId);
                if (selectedCategory==null)
                {
                    Console.WriteLine("Yanlis kategorya");
                    return;
                }
                Console.WriteLine("Qrup onlin dir? Beli/Xeyr:");
                bool isonline = Console.ReadLine().ToLower() == "beli";
                Group group = new Group
                {
                    Category = selectedCategory,
                    No = no,
                    IsOnline=isonline

                };
                Groups.Add(group);
                Console.WriteLine("Group yaradildi");
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
            Console.WriteLine("Deysimek istediyiniz qruou qeyd edin");
            string oldNo = Console.ReadLine();
            var group = Groups.FirstOrDefault(g => g.No == oldNo);
            if (group==null)
            {
                Console.WriteLine("Qrup tapilmadi");
                return;
            }
            Console.Write("Yeni qrup nömrəsini daxil edin: ");
            string newNo = Console.ReadLine();
            if (Groups.Any(g => g.No == newNo))
            {
                Console.WriteLine("Bu adda basqa qrup movcudur");
                return;
            }
            group.No = newNo;
            foreach (var student in group.Students )
            {
                student.GroupNo = newNo;
                Console.WriteLine("Group nomresi deyisdirildi");
            }
        }
        public void ShowGroupsStudents()
        {
            Console.WriteLine("Qrup nomresini daxil edin");
            string no = Console.ReadLine();
            var group = Groups.FirstOrDefault(g => g.No == no);
            if (group==null)
            {
                Console.WriteLine("Qrup tapilmadi");
                return;
            }
            foreach (var student in group.Students)
            {
                Console.WriteLine(student);
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
            Console.Write("Telebenin adi: ");
            string name = Console.ReadLine();
            Console.Write("Telebenin soyadi: ");
            string surname = Console.ReadLine();
            Console.Write("Telebenin qrupunu daxil edin: ");
            string groupNo = Console.ReadLine();
            var group = Groups.FirstOrDefault(g => g.No ==groupNo );
            if (group==null)
            {
                Console.WriteLine("Grup tapilmadi");
                return;
            }
            if (group.Students.Count>=group.Limit)
            {
                Console.WriteLine("Qrup doludur");
                return;
            }
            Console.Write("Telebe tipi(zemanetli/zemanetsiz): ");
            string type = Console.ReadLine();
            Student student = new Student
            {
                Name = name,
                Surname = surname,
                GroupNo = groupNo,
                Type = type

            };
            group.Students.Add(student);
            Console.WriteLine("Telebe elave edildi");
        }

    }
}
