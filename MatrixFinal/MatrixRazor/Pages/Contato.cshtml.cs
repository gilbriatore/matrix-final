using br.edu.up.mtx.dal;
using br.edu.up.mtx.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixRazor.Pages
{
    //[Authorize]
    public class ContatoModel : PageModel
    {

        [BindProperty]
        public Mensagem Mensagem { get; set; }

        private MatrixContext ctx;

        public ContatoModel(MatrixContext ctx)
        {
            this.ctx = ctx;
        }

        public void OnGet()
        {
            /*Mensagem msg = new Mensagem();
            msg.Titulo = "Título de teste";
            msg.Texto = "Texto da mensagem...";
            msg.Nome = "Paulo";
            msg.Email = "paulo@gmail.com";
            Mensagem = msg;*/
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ctx.Mensagems.Add(Mensagem);
            ctx.SaveChanges();
            return RedirectToPage("./Sucesso");
        }
    }
}
