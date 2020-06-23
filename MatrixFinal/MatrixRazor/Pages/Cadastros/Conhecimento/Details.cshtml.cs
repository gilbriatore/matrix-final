using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;

namespace MatrixRazor.Pages.pgConhecimento
{
    public class DetailsModel : PageModel
    {
        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public DetailsModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        public Conhecimento Conhecimento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Conhecimento = await _context.Conhecimentos.FirstOrDefaultAsync(m => m.Id == id);

            if (Conhecimento == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
