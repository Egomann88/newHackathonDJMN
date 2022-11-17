using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VacationPlannerDataAPI.Models;

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

        [HttpPost]
        public JsonResult Post(VacationReason vacationReason)
        {
            string query = @"INSERT INTO VacationReason VALUES ("
                           + "@ID, "
                           + "@VacationReason)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("VacationPlanner");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@VacationReason", vacationReason.Reason);
                    myCommand.Parameters.AddWithValue("@ID", vacationReason.ID);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added sucessfully");
        }
    }
}
