using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;

namespace MatrixRazor.Pages.pgCurso
{
    public class DeleteModel : PageModel
    {
        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public DeleteModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Curso Curso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Curso = await _context.Cursos.FirstOrDefaultAsync(m => m.Id == id);

            if (Curso == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Curso = await _context.Cursos.FindAsync(id);

            if (Curso != null)
            {
                ICollection<PerfilDoCurso> PerfisDoCurso = _context.PerfisDoCurso.Where(x => x.CursoId == Curso.Id).ToList();
                foreach (var Perfil in PerfisDoCurso)
                {
                    _context.PerfisDoCurso.Remove(Perfil);
                }

                _context.Cursos.Remove(Curso);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
