using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputingManagementSystem.Data;
using ComputingManagementSystem.Models;
using ComputingManagementSystem.ViewModels;

namespace ComputingManagementSystem.Controllers
{
    public class ProfessorsController : Controller
    {
        private readonly ComputingManagementSystemContext _context;

        public ProfessorsController(ComputingManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Professors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Professor.ToListAsync());
        }

        // GET: Professors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .Include(s => s.ProfessorSoftware)
                .ThenInclude(ps => ps.Software)
                .FirstOrDefaultAsync(m => m.Id == id);

            var software = await _context.Software.ToListAsync();

            if (professor == null)
            {
                return NotFound();
            }

            ProfessorSoftwareViewModel psViewModel = new ProfessorSoftwareViewModel
            {
                Professor = professor,
                Software = software
            };

            return View(psViewModel);
        }

        // POST: Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail(int id, int sId)
        {
            var teacher = _context.Professor
                 .Include(t => t.ProfessorSoftware)
                 .Single(t => t.Id == id);

            var student = _context.Software.Single(s => s.Id == sId);

            teacher.ProfessorSoftware.Add(new ProfessorSoftware { Professor = teacher, Software = student });

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return Redirect($"/Professors/Details/{id}");
            }


            return Redirect($"/Professors/Details/{id}");


        }

        // GET: Professors/Create
        public IActionResult Create()
        {
            return View();
        }

        [Route("/professors/{id}/SoftwareDelete/{sId}")]
        public IActionResult SoftwareDelete(int id, int sId)
        {
            try
            {
                var professor = _context.Professor
                    .Include(p => p.ProfessorSoftware)
                    .Single(p => p.Id == id);

                var software = _context.Software
                    .Single(s => s.Id == sId);

                professor.ProfessorSoftware.Remove(professor.ProfessorSoftware
                    .Where(ProfessorSoftware => ProfessorSoftware.SoftwareId == sId)
                    .FirstOrDefault());

                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Redirect($"/Professors/Details/{id}");
            }

            return Redirect($"/Professors/Details/{id}");
        }

        // POST: Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ItemCheckedOut")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ItemCheckedOut")] Professor professor)
        {
            if (id != professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professor.FindAsync(id);
            _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professor.Any(e => e.Id == id);
        }
    }
}
