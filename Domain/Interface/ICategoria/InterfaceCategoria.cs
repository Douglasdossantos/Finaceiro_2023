using Domain.Interface.Generic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.ICategoria
{
    public interface InterfaceCategoria :InterfaceGeneric<Categoria>
    {
        Task<IList<Categoria>> ListarCategoriasusuarios(string emailUsuario);
    }
}
