using Domain.Interface.IDespesa;
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
    public class RepositorioDespesa : RepositoryGeneric<Despesa>, InterfaceDespesa
    {
        private readonly DbContextOptions<ContextBase> _optionBuilder;
        public RepositorioDespesa()
        {
            _optionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Despesa>> ListadespesaUsuario(string emailUsuario)
        {
            using (var banco =  new ContextBase(_optionBuilder))
            {
                return await
                    (
                        from s in banco.SistemaFinaceiro
                        join c in banco.Categoria on s.Id equals c.IdSistema
                        join us in banco.UsuarioSistemaFinaceiro on s.Id equals us.IdSistema
                        join d in banco.Despesa on c.Id equals d.IdCategoria
                        where us.EmailUsuario.Equals(emailUsuario) 
                        && s.Mes == d.Mes 
                        && s.Ano == d.Ano
                        select d
                    )
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<IList<Despesa>> ListarDespesasUsuarioNaoPagoMesesAnteriro(string emailUsuario)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                return await
                    (
                        from s in banco.SistemaFinaceiro
                        join c in banco.Categoria on s.Id equals c.IdSistema
                        join us in banco.UsuarioSistemaFinaceiro on s.Id equals us.IdSistema
                        join d in banco.Despesa on c.Id equals d.IdCategoria
                        where us.EmailUsuario.Equals(emailUsuario)
                        && s.Mes < DateTime.Now.Month 
                        && !d.Pago
                        select d
                    )
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
