using Domain.Interface.ICategoria;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class RepositorioCategoria : RepositoryGeneric<Categoria>, InterfaceCategoria
    {
        private readonly DbContextOptions<ContextBase> _optionBuilder;
        public RepositorioCategoria()
        {
            _optionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Categoria>> ListarCategoriasusuarios(string emailUsuario)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                return await
                    (
                        from s in banco.SistemaFinaceiro
                        join c in banco.Categoria on s.Id equals c.IdSistema
                        join us in banco.UsuarioSistemaFinaceiro on s.Id equals us.IdSistema
                        where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual select c
                     )  
                     .AsNoTracking()
                     .ToListAsync();

            }
        }
    }
}
