using Domain.Interface.Generic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.IUsuarioSistemaFinanceiro
{
    public interface InterfaceUsuarioSistemaFinanceiro :InterfaceGeneric<UsuarioSistemaFinanceiro>
    {
        Task<IList<UsuarioSistemaFinanceiro>> ListaUsuariosSistemasFinanceiro(int IdSistema);
        Task RemoverUsuario(List<UsuarioSistemaFinanceiro> Usuarios);
        Task<UsuarioSistemaFinanceiro> ObterusuarioSistemafinanceiro(string emailusuario);
    }
}
