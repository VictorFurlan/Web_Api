using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet]
        public IEnumerable<Mpedido> GetAll()
        {
            return _pedidoRepositorio.GetAll();
        }

        [HttpGet("{Pedido}", Name = "GetPedido")]
        public IActionResult GetById(string Pedido)
        {
            
            var item = _pedidoRepositorio.Find(Pedido);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Mpedido p)
        {
            if (p == null)
            {
                return BadRequest();
            }
            _pedidoRepositorio.Add(p);
            return CreatedAtRoute("GetPedido", new { Pedido = p.pedido }, p);
        }

        [HttpPut("{Pedido}")]
        public IActionResult Update(string Pedido, [FromBody] Mpedido p)
        {
            if (p == null || !p.pedido.Equals(Pedido) )
            {
                return BadRequest();
            }
            var pedido = _pedidoRepositorio.Find(Pedido);
            if (pedido == null)
            {
                return NotFound();
            }
            pedido.pedido = p.pedido;
            _pedidoRepositorio.Update(pedido);
            return new NoContentResult();
        }

        [HttpDelete("{Pedido}")]
        public IActionResult Delete(string Pedido)
        {
            var todo = _pedidoRepositorio.Find(Pedido);
            if (todo == null)
            {
                return NotFound();
            }
            _pedidoRepositorio.Remove(Pedido);
            return new NoContentResult();
        }
    }
}
