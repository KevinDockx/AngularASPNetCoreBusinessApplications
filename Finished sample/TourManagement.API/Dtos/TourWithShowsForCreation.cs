using System.Collections.Generic;

namespace TourManagement.API.Dtos
{
    public class TourWithShowsForCreation : TourForCreation
    {
        public ICollection<ShowForCreation> Shows { get; set; }
          = new List<ShowForCreation>();
    }
}
