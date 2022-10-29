using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationPlannerDataAPI.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserPassword { get; set; }
        public int SuperiorID { get; set; }
        public decimal VacationCredit { get; set; }
        public string UserEmail { get; set; }

    }
}
