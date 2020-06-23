using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;

namespace MatrixRazor.Pages.pgHabilidade
{
    public class DeleteModel : PageModel
    {
        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public DeleteModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Habilidade Habilidade { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Habilidade = await _context.Habilidades.FirstOrDefaultAsync(m => m.Id == id);

            if (Habilidade == null)
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

            Habilidade = await _context.Habilidades.FindAsync(id);

            if (Habilidade != null)
            {
                _context.Habilidades.Remove(Habilidade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
