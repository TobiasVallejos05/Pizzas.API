using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(){
            Pizza Aux;
            Aux = BD.TraerPizzas();
            return Ok(Aux);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            Pizza Aux;
            Aux = BD.TraerPizzasPorId(id);
            return Ok(Aux);
        }

        [HttpPost]
        public IActionResult Create (Pizza pizza){
            Pizza Aux;
            Aux = BD.CrearPizzas(pizza);
            return Ok(Aux);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza){
            Pizza Aux;
            Aux = BD.ActualizarPizzas(id, pizza);
            return Ok(Aux);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id){
            Pizza Aux;
            Aux = BD.EliminarPizzas(id);
            return Ok(Aux);
        }
    }
}
