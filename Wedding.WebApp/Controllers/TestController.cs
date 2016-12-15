using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wedding.Common.Core;

namespace Wedding.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller {
        private readonly IConfigurationManager _configurationManager;

        public TestController(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public IActionResult Welcome()
        {
            return Ok(new
            {
                message = "This is the Welcome action method..."
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var sqlConnectionString = _configurationManager.GetSetting("SqlConnectionString");

            try
            {
                SqlConnection connection = new SqlConnection(sqlConnectionString);
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    return Ok(new
                    {
                        Message = "Its Working"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Message = "Its not Working"
                    });
                }
            }
            catch
            {
                return Ok(new
                {
                    Message = "It Errors"
                });
            }
        }
    }
}