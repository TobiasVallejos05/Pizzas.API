using Pizzas.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

private static string _connectionString = @"Server=NombreMaquina\SQLEXPRESS; DataBase=NombreBase; Trusted_Connection=True;";