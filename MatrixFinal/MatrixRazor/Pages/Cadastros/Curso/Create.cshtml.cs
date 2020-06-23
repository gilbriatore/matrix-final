using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;
using System.Diagnostics;

namespace MatrixRazor.Pages.pgCurso
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Curso Curso { get; set; }
        public SelectList Escolas { get; set; }
        public SelectList Modalidades { get; set; }
        public SelectList TiposDeCurso { get; set; }
        public SelectList Perfis { get; set; }

        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public CreateModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Modalidades = new SelectList(_context.Modalidades, "Id", "Nome");
            Escolas = new SelectList(_context.Escolas, "Id", "Nome");
            TiposDeCurso = new SelectList(_context.TiposDeCurso, "Id", "Nome");
            Perfis = new SelectList(_context.Perfis, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public int EscolaId { get; set; }

        [BindProperty]
        public int ModalidadeId { get; set; }

        [BindProperty]
        public int TipoDeCursoId { get; set; }

        [BindProperty]
        public int[] PerfisId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Escola escola = _context.Escolas.Find(EscolaId);
            Modalidade modalidde = _context.Modalidades.Find(ModalidadeId);
            TipoDeCurso tipo = _context.TiposDeCurso.Find(TipoDeCursoId);
            ICollection<Perfil> perfis = _context.Perfis.Where(x => PerfisId.Any(y => y == x.Id)).ToList();

            ICollection<PerfilDoCurso> perfisDoCurso = new List<PerfilDoCurso>();
            foreach(var perfil in perfis)
            {
                PerfilDoCurso item = new PerfilDoCurso();
                item.CursoId = Curso.Id;
                item.Curso = Curso;
                item.PerfilId = perfil.Id;
                item.Perfil = perfil;
                perfisDoCurso.Add(item);
            }

            Curso.Escola = escola;
            Curso.Modalidade = modalidde;
            Curso.Tipo = tipo;
            Curso.PerfisDoCurso = perfisDoCurso;

            _context.Cursos.Add(Curso);
            _context.PerfisDoCurso.AddRange(perfisDoCurso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
