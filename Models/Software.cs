using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputingManagementSystem.Models
{
    public class Software
    {
        public int Id { get; set; }
        public string SoftwareName { get; set; }
        public string VersionNum { get; set; }
        public string LinkToSoftware { get; set; }
        public List<ProfessorSoftware> ProfessorSoftware { get; set; }
    }
}
