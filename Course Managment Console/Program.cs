using Course_Managment_Console.Models;

namespace Course_Managment_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoursesService courses = new CoursesService();
            while (true)
            {
                Console.WriteLine("1. Yeni qrup yarat");
                Console.WriteLine("2. Qrupların siyahısını goster");
                Console.WriteLine("3. Qrup uzerinde duzeliş et");
                Console.WriteLine("4. Qrupdakı telebelerin siyahısı");
                Console.WriteLine("5. Butun telebelerin siyahısı");
                Console.WriteLine("6. Yeni telebe yarat");
                Console.WriteLine("0. Çıxış");
                Console.Write("Seçim: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": courses.CreatedGroup(); break;
                    case "2": courses.ShowAll(); break;
                    case "3": courses.EditGroup(); break;
                    case "4": courses.ShowGroupsStudents(); break;
                    case "5": courses.ShowAllStudents(); break;
                    case "6": courses.CreatedStudent(); break;
                    case "0":
                        Console.WriteLine("Proqramdan çıxılır...");
                        return;
                    default:
                        Console.WriteLine("Yanlış seçim!");
                        break;
                }
            }
        }
    }
}