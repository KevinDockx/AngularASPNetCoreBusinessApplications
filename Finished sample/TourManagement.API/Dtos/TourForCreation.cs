using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.API.Dtos
{
    public class TourForCreation : TourAbstractBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "required|You must choose a band.")]
        public Guid BandId { get; set; }
    }
}
