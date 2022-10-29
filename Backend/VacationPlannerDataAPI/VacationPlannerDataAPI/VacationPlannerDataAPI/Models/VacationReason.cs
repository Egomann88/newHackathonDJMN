using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace VacationPlannerDataAPI.Models
{
    public class VacationReason
    {
        public int ID { get; set; }
        public string Reason { get; set; }

    }
}
