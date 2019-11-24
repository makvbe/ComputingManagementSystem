using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputingManagementSystem.Models
{
    public class ProfessorSoftware
    {
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int SoftwareId { get; set; }
        public Software Software { get; set; }
    }
}
