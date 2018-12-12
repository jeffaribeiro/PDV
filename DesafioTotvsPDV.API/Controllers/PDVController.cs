using System;
using DesafioTotvsPDV.API.Base;
using DesafioTotvsPDV.API.Inputs;
using DesafioTotvsPDV.API.Outputs;
using DesafioTotvsPDV.Data.Persistencia;
using DesafioTotvsPDV.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTotvsPDV.API.Controllers
{
    [Produces("application/json")]
    [Route("api/pdv")]
    public class PDVController : MyControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PDVController(IUnitOfWork unitOfWork, IPagamentoService pagamentoService) : base(unitOfWork)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpPost("RegistrarPagamento")]
        public IActionResult RegistrarPagamento([FromBody]PagamentoInput input)
        {
            try
            {
                if (input.EhValido())
                {
                    string response = _pagamentoService.ExibirInfoTroco(input.ValorVenda, input.ValorPago);

                    PagamentoOutput output = new PagamentoOutput { InfoTroco = response };
                    
                    return ResponseSuccess(output, _pagamentoService);
                }
                return BadRequest("Dados de entrada inválidos");
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }
    }
}
