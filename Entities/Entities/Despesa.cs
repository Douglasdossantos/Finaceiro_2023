using Entities.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("Despesa")]
    public class Despesa : Base
    {

        public decimal Valor { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public EnumTipoDespesa TipoDespesa {get;set;}
        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }
        public DateTime DataVenciment { get; set; }
        public bool Pago { get; set; }
        public bool DespesaAtrasada { get; set; }

        [ForeignKey("SistemaFinanceiro")]
        [Column(Order = 1)]
        public int IdSistema { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
