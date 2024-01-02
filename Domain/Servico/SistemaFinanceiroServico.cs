using Domain.Interface.InterfaceServico;
using Domain.Interface.ISistemaFinanceiro;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servico
{
    public class SistemaFinanceiroServico : ISistemaFinaceiroServico
    {
        private readonly InterfaceSistemaFinanceiro _InterfaceSistemaFinanceiro;
        public SistemaFinanceiroServico(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro)
        {
            _InterfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
        }
        public async  Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidaPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if (valido)
            {
                var data = DateTime.UtcNow;
                sistemaFinanceiro.DiaFechamento = 1;
                sistemaFinanceiro.Ano = data.Year;
                sistemaFinanceiro.Mes = data.Month;
                sistemaFinanceiro.AnoCopia = data.Year;
                sistemaFinanceiro.MesCopia = data.Month;
                sistemaFinanceiro.GerarCopiaDespesa = true;

                await _InterfaceSistemaFinanceiro.Add(sistemaFinanceiro);
            }
        }

        public async Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidaPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if (valido)
            {
                var data = DateTime.UtcNow;
                sistemaFinanceiro.DiaFechamento = 1;

                await _InterfaceSistemaFinanceiro.Update(sistemaFinanceiro);
            }
        }
    }
}
