using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;

namespace MatrixRazor.Pages.pgDCN
{
    public class DeleteModel : PageModel
    {
        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public DeleteModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DCN DCN { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DCN = await _context.DCNs.FirstOrDefaultAsync(m => m.Id == id);

            if (DCN == null)
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

            DCN = await _context.DCNs.FindAsync(id);

            if (DCN != null)
            {
                _context.DCNs.Remove(DCN);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
