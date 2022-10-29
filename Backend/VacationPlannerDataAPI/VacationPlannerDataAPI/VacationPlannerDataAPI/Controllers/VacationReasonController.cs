using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace VacationPlannerDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationReasonController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public VacationReasonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from [VacationReason]";

            DataTable userTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("VacationPlanner");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    userTable.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(userTable);
        }
    }
}
