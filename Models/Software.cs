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

        public Software()
        {

        }

        public Software(string SoftwareName)
        {

        }

        public Software(string SofwareName, string LinkToSoftware)
        {

        }

        public Software(string SoftwareName, string LinkToSoftware, string VersionNum)
        {

        }

        /*public Software(string SoftwareName, string VersionNum)
        {

        }*/

        public void AddRequest(Professor professor)
        {

        }
    }
}
