using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Pizzas.API.Services;
using Pizzas.API.Utils;
using System.Data.SqlClient;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {

            try{
            List<Usuario> ListaUsuarios = BD_Usuarios.TraerUsuarios();
            return Ok(ListaUsuarios);
            }
             catch(Exception error){
               return NotFound(error);
           }
        }

        [HttpPost]
        public IActionResult Create(Usuario UnUsuario)
        {
            int UsuarioCreado;

            try{
            UsuarioCreado = BD_Usuarios.CrearUsuarios(UnUsuario);
            if (UsuarioCreado == 0){
                return BadRequest();
            }
            else{
                return Ok(UnUsuario);
            }
            }
             catch(Exception error){
               return NotFound(error);
           }
        }

        // ver si necesitan id
        [HttpPut("{id}")]
        public IActionResult Update(int Id, Usuario UnUsuario)
        {
           try{
               return Ok(BD_Usuarios.ActualizarUsuarios(UnUsuario));
           }
           catch(Exception error){
               return NotFound(error);
           }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try{ 
                return Ok(BD_Usuarios.EliminarUsuarios(id));
            }
             catch(Exception error)
            {
               return NotFound(error);
            }
        }
    }
}
