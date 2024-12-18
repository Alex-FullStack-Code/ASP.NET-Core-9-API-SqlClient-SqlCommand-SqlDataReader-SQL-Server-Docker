using HMDB.Models.BindingModels;
using HMDB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HMDB.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        DatabaseConnection dc = new DatabaseConnection();
        String query;


        [HttpPost]
        public async Task<LoginViewModel> Login([FromBody] LoginBindingModel model)
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT NewUser FROM Login WHERE username = '" + model.Username + "' AND password = '" + model.Password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            LoginViewModel str = new LoginViewModel();
            while (reader.Read())
            { 
                str.LoginId = reader.GetInt32(reader.GetOrdinal("LoginId")); 
                str.Username = reader.GetString(reader.GetOrdinal("Username"));
                str.EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                str.HotelId = reader.GetInt32(reader.GetOrdinal("HotelId"));  
            }
            con.Close();
            return str;
        }

        [HttpGet]
        public async Task<LoginViewModel> Login2([FromBody] LoginBindingModel model)
        {
            SqlConnection con = dc.getConnection();
            con.Open();
            query = "SELECT NewUser FROM Login WHERE username = '" + model.Username + "' AND password = '" + model.Password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            LoginViewModel str = new LoginViewModel();
            while (reader.Read())
            {
                str.LoginId = reader.GetInt32(reader.GetOrdinal("LoginId"));
                str.Username = reader.GetString(reader.GetOrdinal("Username"));
                str.EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                str.HotelId = reader.GetInt32(reader.GetOrdinal("HotelId"));
            }
            con.Close();
            return str;
        }
    }
}
