using Entities.Animal;
using Entities.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Seeding
{
    public class SeedingService
    {
        ApplicationDbContext db;

        public SeedingService(ApplicationDbContext context)
        {
            db = context;
        }
        public void SeedStudent()
        {
            Student s1 = new Student() { Name = "Anna", Age = 32 };
            Student s2 = new Student() { Name = "MAria", Age = 36 };
            Student s3 = new Student() { Name = "Leonidas", Age = 37 };
            Student s4 = new Student() { Name = "Giorgos", Age = 33 };
            Student s5 = new Student() { Name = "Fotini", Age = 36 };

            Project p1 = new Project() { Title = "C#" };
            Project p2 = new Project() { Title = "Python" };
            Project p3 = new Project() { Title = "C++" };
            Project p4 = new Project() { Title = "Javascript" };
            Project p5 = new Project() { Title = "Java" };



            p1.Student = s1;
            p2.Student = s2;
            p3.Student = s3;
            p4.Student = s4;
            p5.Student = s5;

            db.Projects.Add(p1);
            db.Projects.Add(p3);
            db.Projects.Add(p2);
            db.Projects.Add(p4);
            db.Projects.Add(p5);


            db.Students.Add(s1);
            db.Students.Add(s2);
            db.Students.Add(s3);
            db.Students.Add(s4);
            db.Students.Add(s5);

            db.SaveChanges();
        }
        public void SeedAnimal()
        {
            Tiger t1 = new Tiger() { TigerName = "Maria" };
            Tiger t2 = new Tiger() { TigerName = "Lion" };
            Tiger t3 = new Tiger() { TigerName = "Catan" };
            Tiger t4 = new Tiger() { TigerName = "Chitara" };
            Tiger t5 = new Tiger() { TigerName = "Milka" };

            db.Tigers.Add(t1);
            db.Tigers.Add(t2);
            db.Tigers.Add(t3);
            db.Tigers.Add(t4);
            db.Tigers.Add(t5);
            db.SaveChanges();


            Horse h1 = new Horse() { Name = "Panos" };
            Horse h2 = new Horse() { Name = "Vagos" };
            Horse h3 = new Horse() { Name = "Nikos" };
            Horse h4 = new Horse() { Name = "Magas" };
            Horse h5 = new Horse() { Name = "Alani" };

            db.Horses.Add(h1);
            db.Horses.Add(h2);
            db.Horses.Add(h3);
            db.Horses.Add(h4);
            db.Horses.Add(h5);
            db.SaveChanges();

            Penguin p1 = new Penguin() { Name = "Oz" };
            Penguin p2 = new Penguin() { Name = "Lady" };
            Penguin p3 = new Penguin() { Name = "Lois" };
            Penguin p4 = new Penguin() { Name = "Peach" };
            Penguin p5 = new Penguin() { Name = "Bruce" };

            db.Penguins.Add(p1);
            db.Penguins.Add(p2);
            db.Penguins.Add(p3);
            db.Penguins.Add(p4);
            db.Penguins.Add(p5);

        }
    }
}
