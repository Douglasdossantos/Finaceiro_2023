using Domain.Interface.InterfaceServico;
using Domain.Interface.ISistemaFinanceiro;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceSistemaFinanceiro _InterfaceSistemaFinanceiro;
        private  readonly ISistemaFinaceiroServico _IstemaFinaceiroServico;
        public SistemaFinanceiroController(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro, 
            ISistemaFinaceiroServico istemaFinaceiroServico)
        {
            _InterfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
            _IstemaFinaceiroServico = istemaFinaceiroServico;
        }

        [HttpGet("api/ListaSistemaUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuarios(string emailUsuario)
        {
            return await _InterfaceSistemaFinanceiro.ListaSistemasUsuario(emailUsuario);
        }

        [HttpPost("api/AdicionarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _IstemaFinaceiroServico.AdicionarSistemaFinanceiro(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }
        [HttpPut("api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _IstemaFinaceiroServico.AtualizarSistemaFinanceiro(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpGet("api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinanceiro(int Id)
        {
            return  await _InterfaceSistemaFinanceiro.getEntityById(Id);
        }
        [HttpDelete("api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeletarSistemaFinanceiro(int Id)
        {
            try
            {
                var  sistemaFinanceiro = await _InterfaceSistemaFinanceiro.getEntityById(Id);
                return _InterfaceSistemaFinanceiro.Delete(sistemaFinanceiro);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
