using Application.Interfaces;
using ApplicationDTO;
//using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carvajal.Services.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoApplication _pedidoApplication;

        public PedidoController(IPedidoApplication pedidoApplication)
        {
            _pedidoApplication = pedidoApplication;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarPedido([FromBody] CreatePedidoDTO pedido)
        {
            var response = await _pedidoApplication.CreatePedido(pedido);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPedido(int id)
        {
            var response = await _pedidoApplication.GetPedido(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]

        public async Task<IActionResult> ObtenerPedidos()
        {
            var response = await _pedidoApplication.GetPedidos();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> EliminarPedido(int id)
        {
            var response = await _pedidoApplication.DeletePedido(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }

    }
}
