using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.API.Dtos
{
    public class TourWithManagerForCreation : TourForCreation
    {
        public string ManagerId { get; set; }
    }
}
