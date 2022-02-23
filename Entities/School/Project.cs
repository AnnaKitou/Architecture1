using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.School
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
