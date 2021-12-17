using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication3.Models
{
    public class Transacoes
    {
        public int Id { get; set; }

        public string Transacao { get; set; }

        public string Usuario { get; set; }

        public DateTime Data { get; set; }

        public string Local { get; set; }

        public int IdEquipamento { get; set; }
    }
}
