using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        int flag = 0;
        private readonly IStatusRepositorio _statusRepositorio;
        public StatusController(IStatusRepositorio statusRepositorio)
        {
            _statusRepositorio = statusRepositorio;
        }

        Status status = new Status();

        [HttpPost]
        public IActionResult Create([FromBody] Status s)
        {
            Mpedido p = _statusRepositorio.Find(s.pedido);

            if (s.pedido == null || s.pedido.Equals(""))
            {
                status.pedido = s.pedido;
                status.status ="CODIGO_PEDIDO_INVALIDO";
            }

            long totalItens = p.itens.Sum(x => Convert.ToInt32(x.qtd));
            long valorTotal = p.itens.Sum(x => Convert.ToInt32(x.qtd * x.precoUnitario));

            if (s.status.ToUpper().Equals("APROVADO"))
            {
                if (s.itensAprovados == totalItens && s.valorAprovado == valorTotal)
                {
                    status.pedido = s.pedido;
                    status.status = "APROVADO";
                    return new ObjectResult(status);
                }
                if (s.status.ToUpper().Equals("REPROVADO"))
                {
                    status.pedido = s.pedido;
                    status.status = "REPROVADO";
                    return new ObjectResult(status);
                }
                if (s.valorAprovado < valorTotal)
                {
                    status.pedido = s.pedido;
                    status.status += "APROVADO_VALOR_A_MENOR";
                    flag = 1;
                }
                if (s.itensAprovados < totalItens)
                {
                    if(flag == 1)
                    {
                        status.status += ", ";
                    }
                    status.pedido = s.pedido;
                    status.status += "APROVADO_QTD_A_MENOR";
                    flag = 2;
                }
                if (s.valorAprovado > valorTotal)
                {
                    if (flag == 2 || flag == 1)
                    {
                        status.status += ", ";
                    }
                    status.pedido = s.pedido;
                    status.status += "APROVADO_VALOR_A_MAIOR";
                    flag = 3;
                }
                if (s.itensAprovados > totalItens)
                {
                    if (flag !=0 )
                    {
                        status.status += ", ";
                    }
                    status.pedido = s.pedido;
                    status.status += "APROVADO_QTD_A_MAIOR";
                }
            }
            return new ObjectResult(status);
        }
    }
}
