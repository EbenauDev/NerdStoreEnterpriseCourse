using Microsoft.AspNetCore.Mvc;
using NSE.WebAPI.Core.Controllers;
using System;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Controllers
{
    public class ClientesController : MainController
    {

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}
