using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;

namespace MatrixRazor.Pages.pgCompetencia
{
    public class IndexModel : PageModel
    {
        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public IndexModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        public IList<Competencia> Competencia { get;set; }

        public async Task OnGetAsync()
        {
            Competencia = await _context.Competencias.ToListAsync();
        }
    }
}
