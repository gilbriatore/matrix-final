using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;

namespace MatrixRazor.Pages.pgCurso
{
    public class EditModel : PageModel
    {
        private readonly br.edu.up.mtx.dal.MatrixContext _context;

        public EditModel(br.edu.up.mtx.dal.MatrixContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Curso Curso { get; set; }
        public SelectList Escolas { get; set; }
        public SelectList Modalidades { get; set; }
        public SelectList TiposDeCurso { get; set; }
        public SelectList Perfis { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Modalidades = new SelectList(_context.Modalidades, "Id", "Nome");
            Escolas = new SelectList(_context.Escolas, "Id", "Nome");
            TiposDeCurso = new SelectList(_context.TiposDeCurso, "Id", "Nome");
            Perfis = new SelectList(_context.Perfis, "Id", "Nome");

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
            EscolaId = Curso.Escola.Id;
            ModalidadeId = Curso.Modalidade.Id;
            TipoDeCursoId = Curso.Tipo.Id;
            PerfisId = Curso.PerfisDoCurso.Select(p => p.PerfilId).ToArray();

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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Curso).State = EntityState.Modified;

            try
            {
                ICollection<PerfilDoCurso> PerfisDoCurso = _context.PerfisDoCurso.Where(x => x.CursoId == Curso.Id).ToList();
                foreach (var Perfil in PerfisDoCurso)
                {
                    _context.PerfisDoCurso.Remove(Perfil);
                }

                Escola escola = _context.Escolas.Find(EscolaId);
                Modalidade modalidde = _context.Modalidades.Find(ModalidadeId);
                TipoDeCurso tipo = _context.TiposDeCurso.Find(TipoDeCursoId);
                ICollection<Perfil> perfis = _context.Perfis.Where(x => PerfisId.Any(y => y == x.Id)).ToList();

                ICollection<PerfilDoCurso> perfisDoCurso = new List<PerfilDoCurso>();
                foreach (var perfil in perfis)
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
                _context.PerfisDoCurso.AddRange(perfisDoCurso);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(Curso.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(e => e.Id == id);
        }
    }
}
