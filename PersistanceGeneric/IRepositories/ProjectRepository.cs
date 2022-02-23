using Entities.School;
using MyDatabase;
using PersistanceGeneric.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceGeneric.IRepositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Project> GetProjectsOrderBy()
        {
            return Context.Projects.OrderBy(x => x.Title).ToList();
        }
    }
}
