using Domain.Interface.ICategoria;
using Domain.Interface.InterfaceServico;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servico
{
    public class CategoriaServico : ICategoriaServico
    {
        private readonly InterfaceCategoria _InterfaceCategoria;

        public CategoriaServico( InterfaceCategoria interfaceCategoria)
        {
            _InterfaceCategoria = interfaceCategoria;            
        }
        public async Task AdicionarCategoria(Categoria categoria)
        {
            var valido = categoria.ValidaPropriedadeString(categoria.Nome,"Nome");
            if (valido)
            {
                await _InterfaceCategoria.Add(categoria);
            }
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            var valido = categoria.ValidaPropriedadeString(categoria.Nome, "Nome");
            if (valido)
            {
                await _InterfaceCategoria.Update(categoria);
            }
        }
    }
}
