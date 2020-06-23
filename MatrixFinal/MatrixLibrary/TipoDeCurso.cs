using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace br.edu.up.mtx.domain {
	public class TipoDeCurso {
		public int Id { get; set; }
		[Display(Name = "Tipo")]
		public string Nome { get; set; }
		[Display(Name = "Descrição")]
		public string Descricao { get; set; }

	}//end TipoDeCurso

}//end namespace br.edu.up.mtx.domain