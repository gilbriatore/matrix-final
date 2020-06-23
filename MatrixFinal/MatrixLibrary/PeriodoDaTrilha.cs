using br.edu.up.mtx.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.up.mtx.domain
{
    public class PeriodoDaTrilha
    {
        public int PeriodoId { get; set; }
        public Periodo Periodo { get; set; }

        public int TrilhaId { get; set; }
        public Trilha Trilha { get; set; }
    }
}
