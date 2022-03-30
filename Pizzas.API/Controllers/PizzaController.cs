using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Pizzas.API.Services;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(){
            List<Pizza> ListaPizzas = PizzasServices.TraerPizzas();
            return Ok(ListaPizzas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id){
            Pizza UnaPizza = PizzasServices.TraerPizzasPorId(Id);
            if (UnaPizza == null){
                return NotFound();
            }
            return Ok(UnaPizza);
        }

        [HttpPost]
        public IActionResult Create(Pizza UnaPizza){
            int PizzaCreada;
            PizzaCreada = PizzasServices.CrearPizzas(UnaPizza);
            if (PizzaCreada == 0){
                return BadRequest();
            }
            else{
                return Ok(UnaPizza);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int Id, Pizza UnaPizza){
            int PizzaCambiada;
            if (Id != UnaPizza.Id){
                return BadRequest();
            }
            Pizza PizzaExistente = PizzasServices.TraerPizzasPorId(Id);
            if (PizzaExistente == null){
                return NotFound();
            }

            PizzaCambiada = PizzasServices.ActualizarPizzas(UnaPizza);
            if(PizzaCambiada == 0){
                return BadRequest();
            }
            else{
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id){
            Pizza PizzaExistente = PizzasServices.TraerPizzasPorId(id);
            if(PizzaExistente == null){
                return NotFound();
            }
            BD.Delete(Id);
            return Ok();
        }
    }
}
