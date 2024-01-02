using Domain.Interface.IDespesa;
using Domain.Interface.InterfaceServico;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servico
{
    public class DespesaServico : IDespesaServico
    {
        private readonly InterfaceDespesa _InterfaceDespesa;
        public DespesaServico(InterfaceDespesa interfaceDespesa)
        {
            _InterfaceDespesa = interfaceDespesa;            
        }
        public async Task AdicionarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataCadastro = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;
            var valido = despesa.ValidaPropriedadeString(despesa.Nome, "Nome");
            if (valido)
            {
                await _InterfaceDespesa.Add(despesa);
            }
        }

        public async Task AtualizarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;
            var valido = despesa.ValidaPropriedadeString(despesa.Nome, "Nome");

            if (despesa.Pago)
            {
                despesa.DataPagamento = data;
            }
            if (valido)
            {
                await _InterfaceDespesa.Update(despesa);
            }
        }
    }
}
