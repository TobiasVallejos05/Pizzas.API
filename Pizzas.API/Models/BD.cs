using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using System.Data.SqlClient;
using Dapper;

namespace Pizzas.API.Models
{
    public class BD{
        private static string _connectionstring=@"Server=A-CEO-12;Database=Base;Trusted_Connection=True;";

        public static List<Pizza> TraerPizzas(){
            List<Pizza> Pizzas = new List<Pizza>();
            string sql = "SELECT * FROM Pizzas";
            using (SqlConnection db = new SqlConnection(_connectionstring)){
                Pizzas = DB.Query<Pizza>(sql).ToList();
            } 
            return Pizzas;  
        }

        public static Pizza TraerPizzasPorId(int Id){
            Pizza UnaPizza = null;
            string sql = "SELECT * FROM Pizzas WHERE Id = @pId";
            using (SqlConnection db = new SqlConnection(_connectionstring)){
                UnaPizza = DB.QueryFirstOrDefault<Pizza>(sql, new {pId = Id});
            }
            return UnaPizza;   
        }
        public static int CrearPizzas(Pizza PizzaACrear){
            int RegistroCreado = 0;
            string sql = "INSERT INTO Pizzas (Nombre, LibreGluten, Importe, Descripcion) Values (@pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
            using (SqlConnection db = new SqlConnection(_connectionstring)){
                RegistroCreado = DB.Execute(sql, new {pNombre = PizzaACrear.Nombre, pLibreGluten=PizzaACrear.LibreGluten, pImporte = PizzaACrear.Importe, pDescripcion = PizzaACrear.Descripcion});
            }   
            return RegistroCreado;
        }

        public static int ActualizarPizzas(Pizza PizzaACambiar){
            int RegistroActualizado = 0;
            string sql="UPDATE Pizzas SET Nombre = @pNombre, LibreGluten = @pLibreGluten, Importe = @pImporte, Descripcion = @pDescripcion WHERE Id = @pId";
            using (SqlConnection db = new SqlConnection(_connectionstring)){
                RegistroActualizado = DB.Execute(sql, new {pId = PizzaACambiar.Id, pNombre = PizzaACambiar.Nombre, pLibreGluten = PizzaACambiar.LibreGluten, pImporte = PizzaACambiar.Importe, pDescripcion = PizzaACambiar.Descripcion});
            }
            return RegistroActualizado;   
        }

        public static void EliminarPizzas(int Id){
            string sql = "DELETE FROM Pizzas WHERE Id = @pId";
            using (SqlConnection db = new SqlConnection(_connectionstring)){
                DB.Execute(sql, new {pId = Id});
            }   
        }
    }
}