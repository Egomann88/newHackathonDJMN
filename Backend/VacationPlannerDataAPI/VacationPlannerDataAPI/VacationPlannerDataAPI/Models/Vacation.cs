using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationPlannerDataAPI.Models
{
    public class Vacation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string VacDayDate { get; set; }
        public bool IsFullDay { get; set; }
        public bool IsApproved { get; set; }
        public int VacationReasonID { get; set; }

    }
}
