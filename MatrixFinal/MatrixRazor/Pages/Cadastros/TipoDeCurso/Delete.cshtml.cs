using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;

namespace MatrixRazor.Pages.pgTipoDeCurso
{
    public class DeleteModel : PageModel
    {
        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public DeleteModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TipoDeCurso TipoDeCurso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoDeCurso = await _context.TiposDeCurso.FirstOrDefaultAsync(m => m.Id == id);

            if (TipoDeCurso == null)
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

            TipoDeCurso = await _context.TiposDeCurso.FindAsync(id);

            if (TipoDeCurso != null)
            {
                _context.TiposDeCurso.Remove(TipoDeCurso);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
