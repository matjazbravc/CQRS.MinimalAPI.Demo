using CQRS.MinimalAPI.Demo.Models;

namespace CQRS.MinimalAPI.Demo.Data
{
    public class DataSeeder
    {
        public static void Seed(DataContext context)
        {
            if (context.Students != null && !context.Students.Any())
            {
                context.Students.AddRange(GetPreconfiguredStudents());
                context.SaveChanges();
            }
        }

        // Demo dataset
        private static IEnumerable<Student> GetPreconfiguredStudents()
        {
            return new List<Student>()
            {
                new Student("Tonny Blatt", "Str. 1c", "tony@gmail.com", new DateTime(1991, 10, 7)),
                new Student("Anitta Goldman", "Str. 2c", "Anita@gmail.com", new DateTime(1975, 5, 31)),
                new Student("Alan Ford", "Str. 3c", "alan@gmail.com", new DateTime(2000, 8, 26)),
                new Student("Jim Beam", "Str. 4c", "jim@gmail.com", new DateTime(1984, 1, 12)),
                new Student("Suzanne White", "Str. 5c", "suzanne@gmail.com", new DateTime(1992, 3, 10)),
            };
        }
    }
}
