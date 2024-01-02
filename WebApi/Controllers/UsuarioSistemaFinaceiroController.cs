using Domain.Interface.InterfaceServico;
using Domain.Interface.IUsuarioSistemaFinanceiro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioSistemaFinaceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _InterfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinaceiroServico _UsuarioSistemaFinaceiroServico;

        public UsuarioSistemaFinaceiroController(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro,
            IUsuarioSistemaFinaceiroServico usuarioSistemaFinaceiroServico)
        {
            _InterfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _UsuarioSistemaFinaceiroServico = usuarioSistemaFinaceiroServico;
        }

    }
}
