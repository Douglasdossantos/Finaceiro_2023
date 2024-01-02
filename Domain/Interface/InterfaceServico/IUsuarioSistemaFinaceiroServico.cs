using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.InterfaceServico
{
    public interface IUsuarioSistemaFinaceiroServico
    {
        Task CadastroUsuariosSistemas(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);
    }
}
