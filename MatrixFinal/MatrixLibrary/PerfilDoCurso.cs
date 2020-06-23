using br.edu.up.mtx.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.up.mtx.domain
{
    public class PerfilDoCurso
    {
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
