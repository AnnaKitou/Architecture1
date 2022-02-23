using Entities.School;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace PersistanceLayerNoGeneric.Repositories
{
    public class ProjectRepository
    {
        protected readonly ApplicationDbContext Context;

        public ProjectRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            var projects = Context.Projects.Include(x => x.Student);
            return projects.ToList();
        }
        public Project Get(int id)
        {
            var project = Context.Projects.Find(id);
            return project;
        }
        public IEnumerable<Project> Find(Expression<Func<Project, bool>> predicate)
        {
            return Context.Projects.Where(predicate);
        }
        public Project SingleOrDefault(Expression<Func<Project, bool>> predicate)
        {
            var project = Context.Projects.SingleOrDefault(predicate);
            return project;
        }
        public IEnumerable<IGrouping<ICollection<Project>, Student>> GroupByProjectTitle()
        {

            var students = from st in Context.Students
                           group st by st.Projects into g
                           select g;

            return students.ToList();
        }
        public void Add(Project project)
        {
            Context.Projects.Add(project);
            Context.SaveChanges();

        }
        public void AddRange(IEnumerable<Project> projects)
        {
            Context.Projects.AddRange(projects);
            Context.SaveChanges();

        }
        public void Remove(Project project)
        {
            Context.Projects.Remove(project);
            Context.SaveChanges();

        }
        public void Remove(int id)
        {
            var project = Context.Projects.Find(id);
            if (project == null)
            {
                throw new ArgumentException("Project does not exist");

            }
            Context.Projects.Remove(project);
            Context.SaveChanges();

        }
        public void RemoveRange(IEnumerable<Project> projects)
        {
            Context.Projects.RemoveRange(projects);
            Context.SaveChanges();

        }
        public void Edit(Project project)
        {
            var pro = Context.Projects.Find(project.StudentId);
            if (pro == null)
            {
                throw new ArgumentException("Student does not exist");

            }
            Context.Entry(pro).State = EntityState.Modified;
            Context.SaveChanges();

        }
        public void AssignStudentToProject(Project projects, Student student)
        {
            throw new NotImplementedException("Nope");

        }
    }
}
