using Domain.Interface.InterfaceServico;
using Domain.Interface.IUsuarioSistemaFinanceiro;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servico
{
    public class UsuarioSistemaFinanceiroServico : IUsuarioSistemaFinaceiroServico
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _InterfaceUsuarioSistemaFinanceiro;
        public UsuarioSistemaFinanceiroServico(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro)
        {
            _InterfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
        }

        public async Task CadastroUsuariosSistemas(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {

            await _InterfaceUsuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}
