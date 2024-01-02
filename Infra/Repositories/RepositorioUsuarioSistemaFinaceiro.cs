using Domain.Interface.IUsuarioSistemaFinanceiro;
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
    public class RepositorioUsuarioSistemaFinaceiro : RepositoryGeneric<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _optionBuilder;
        public RepositorioUsuarioSistemaFinaceiro()
        {
            _optionBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<UsuarioSistemaFinanceiro>> ListaUsuariosSistemasFinanceiro(int IdSistema)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                return await banco.UsuarioSistemaFinaceiro
                    .Where( s => s.IdSistema == IdSistema)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterusuarioSistemafinanceiro(string emailusuario)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                return await banco.UsuarioSistemaFinaceiro
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.EmailUsuario == emailusuario);
            }
        }

        public async Task RemoverUsuario(List<UsuarioSistemaFinanceiro> Usuarios)
        {
            using (var banco = new ContextBase(_optionBuilder))
            {
                banco.UsuarioSistemaFinaceiro.RemoveRange(Usuarios);
                await banco.SaveChangesAsync();
            }
        }
    }
}
