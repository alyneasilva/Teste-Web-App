using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Equipamentos
    {
        public int Id { get; set; }
        public string Equipamento { get; set; }
        public string Modelo { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Local { get; set; }
        public string Armario { get; set; }
        public int Prateleira { get; set; }
        public string SistOper { get; set; }
        public string AplicativoInstalado { get; set; }
        public string SistemaAutomação { get; set; }
        public string Status { get; set; }
        public string PC { get; set; }
        public string RC { get; set; }
        public string ItemRC { get; set; }

        public string NF { get; set; }
        public DateTime DataGarantia { get; set; }

        public string Observacao { get; set; }

    }

}
