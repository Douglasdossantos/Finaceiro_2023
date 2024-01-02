using Domain.Interface.ISistemaFinanceiro;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class RepositorioSistemaFinaceiro : RepositoryGeneric<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _optionBuilder;
        public RepositorioSistemaFinaceiro()
        {
            _optionBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<SistemaFinanceiro>> ListaSistemasUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                return await
                    (
                        from s in banco.SistemaFinaceiro
                        join us in banco.UsuarioSistemaFinaceiro on s.Id equals us.IdSistema
                        where us.EmailUsuario.Equals(emailUsuario)
                        select s
                    )
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
