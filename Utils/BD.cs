using Microsoft.Extensions.Configuration;
using System.IO;

namespace Pizzas.API.Utils {
    public class BD {
        public static SqlConnection GetConnection(){
            SqlConnection db;
            string connectionString;
            connectionString = ConfigurationHelper.GetConfiguration().GetValue<string>("DatabaseSettings:ConnectionString");
            db = new SqlConnection(connectionString);
            return db;
        }
    }
}