using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputingManagementSystem.Models;

namespace ComputingManagementSystem.ViewModels
{
    public class ProfessorSoftwareViewModel
    {
        public Professor Professor { get; set; }
        public List<Software> Software  { get; set; }
    }
}
