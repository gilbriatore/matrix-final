using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MatrixRazor.Pages.pgCurso
{
    public class DetailsModel : PageModel
    {
        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public DetailsModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        public Curso Curso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Curso = await _context.Cursos.Include(Curso => Curso.Modalidade)
                .Include(Curso => Curso.Escola)
                .Include(Curso => Curso.Tipo)
                .Include(Curso => Curso.PerfisDoCurso)
                .ThenInclude(PerfilDoCurso => PerfilDoCurso.Perfil)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Curso == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
