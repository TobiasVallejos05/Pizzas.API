using Pizzas.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

namespace Pizzas.API.Models{ 
    public static class db { 
        private static string _connectionString = @"Server=A-CEO-77; DataBase=Pizzas; Trusted_Connection=True;";

public static List <Pizza> TraerPizzas()
{
    List <Pizza> _ListadoPizzas = null;
    using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM Pizzas";
        _ListadoPizzas = db.Query<Pizza>(sql).ToList();
    }
    return _ListadoPizzas;
}

public static Pizza TraerPizzasPorId(int Id)
{
    Pizza PizzaPorId = null;
    using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Pizzas WHERE Id = @pId";
            PizzaPorId = db.QueryFirstOrDefault<Pizza>(sql, new {pId = Id});
    }
    return PizzaPorId;
}

public static int CrearPizzas(Pizza PizzaACrear)
   {
       int RegistrosCreados = 0;
       string sql = "INSERT INTO Pizzas (Id, Nombre, LibreGluten, Importe, Descripcion) VALUES = (@pId, @pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
       using(SqlConnection db = new SqlConnection(_connectionString)){
           RegistrosCreados = db.Execute(sql, new {Pizzas = PizzaACrear});
       }
       return RegistrosCreados;
   }

public static int ActualizarPizzas(int Id, Pizza PizzaAActualizar)
   {
       int RegistrosActualizados = 0;
       string sql = "UPDATE Pizzas SET Nombre = @pNombre, LibreGluten = @pLibreGluten, Importe = @pImporte, Descripcion = @Descripcion WHERE Id = @pId";
       using(SqlConnection db = new SqlConnection(_connectionString)){
           RegistrosActualizados = db.Execute(sql, new {Pizzas = PizzaAActualizar});
       }
       return RegistrosActualizados;
   }


public static int EliminarPizzas(string PizzaAEliminar)
   {
       int RegistrosEliminados = 0;
       string sql = "DELETE FROM Pizzas WHERE Id = @Id";
       using(SqlConnection db = new SqlConnection(_connectionString)){
           RegistrosEliminados = db.Execute(sql, new {Pizzas = PizzaAEliminar});
       }
       return RegistrosEliminados;
   }}}