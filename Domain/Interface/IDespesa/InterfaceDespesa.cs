using Domain.Interface.Generic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.IDespesa
{
    public interface InterfaceDespesa : InterfaceGeneric<Despesa>
    {
        Task<IList<Despesa>> ListadespesaUsuario(string emailusuario);

        Task<IList<Despesa>> ListarDespesasUsuarioNaoPagoMesesAnteriro(string emailUsuario);
    }
}
