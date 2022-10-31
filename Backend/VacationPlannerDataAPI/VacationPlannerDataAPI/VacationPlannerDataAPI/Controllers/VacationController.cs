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
    public class VacationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public VacationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select ID,UserID,convert(varchar(10),VacStartDate,120) as VacStartDate,IsFullDay,IsApproved,VacationReasonID,convert(varchar(10),VacEndDate,120) as VacEndDate, Comment from [Vacation]";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("VacationPlanner");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Vacation vacation)
        {
            string query = @"INSERT INTO Vacation VALUES ("
                           +"@UserID, "
                           + "@VacStartDate, "
                           + "@IsFullDay, "
                           +"@IsApproved, "
                           +"@VacationReasonID,"
                           +"@VacEndDate,"
                           + "@Comment)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("VacationPlanner");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserID", vacation.ID);
                    myCommand.Parameters.AddWithValue("@VacStartDate", vacation.VacStartDate);
                    myCommand.Parameters.AddWithValue("@IsFullDay", vacation.IsFullDay);
                    myCommand.Parameters.AddWithValue("@IsApproved", vacation.IsApproved);
                    myCommand.Parameters.AddWithValue("@VacationReasonID", vacation.VacationReasonID);
                    myCommand.Parameters.AddWithValue("@VacEndDate", vacation.VacEndDate);
                    myCommand.Parameters.AddWithValue("@Comment", vacation.Comment);
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
