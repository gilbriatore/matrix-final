using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;

namespace MatrixRazor.Pages.pgConhecimento
{
    public class CreateModel : PageModel
    {
        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public CreateModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Conhecimento Conhecimento { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Conhecimentos.Add(Conhecimento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
