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
        public string Tipo { get; set; }
        public string Local { get; set; }
        public string Armario { get; set; }
        public int Prateleira { get; set; }
        public string AplicativoInstalado { get; set; }
        public string SistemaAutomação { get; set; }
        public string Status { get; set; }
        public string LocalUtilização { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get; set; }

    }
}
