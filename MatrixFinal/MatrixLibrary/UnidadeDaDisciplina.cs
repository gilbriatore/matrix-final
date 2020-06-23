using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace br.edu.up.mtx.domain {
	public class UnidadeDaDisciplina {
		public int DisciplinaId { get; set; }
		public Disciplina Disciplina { get; set; }

        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; } 
    }

}//end namespace br.edu.up.mtx.domain