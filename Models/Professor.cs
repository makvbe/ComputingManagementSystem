using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputingManagementSystem.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public List<Systems> Systems { get; set; }
        public List<ProfessorSoftware> ProfessorSoftware { get; set; }
        public bool ItemCheckedOut { get; set; }
    }
}
