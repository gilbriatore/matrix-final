using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.up.mtx.domain
{
    public class Mensagem
    {
        public int Id { get; set; }
        public String Titulo { get; set; }
        public String Texto { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
    }
}