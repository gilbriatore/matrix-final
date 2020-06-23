using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;

namespace MatrixRazor.Pages.pgModalidade
{
    public class DetailsModel : PageModel
    {
        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public DetailsModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        public Modalidade Modalidade { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Modalidade = await _context.Modalidades.FirstOrDefaultAsync(m => m.Id == id);

            if (Modalidade == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
