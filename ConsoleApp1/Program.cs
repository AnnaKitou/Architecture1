using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistanceGeneric.Repositories;
using Entities.School;
using PersistanceGeneric.IRepositories;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            ProjectRepository projectService = new ProjectRepository(context);
            var projects = projectService.GetProjectsOrderBy();
            foreach (var pro in projects)
            {
                Console.WriteLine(pro.Title);
            }

            //GenericRepository<Project> projectservice = new  GenericRepository<Project>(context);
            //GenericRepository<Student> studentservice = new  GenericRepository<Student>(context);

            //var projects=projectservice.GetAll();
            //foreach (var pro in projects)
            //{
            //    Console.WriteLine(pro.Title);
            //}
            //var students = studentservice.GetAll();
            //foreach (var stu in students)
            //{
            //    Console.WriteLine(stu.Name);
            //}
        }
    }
}
