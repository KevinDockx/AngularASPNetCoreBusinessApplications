using System.Collections.Generic;

namespace TourManagement.API.Dtos
{
    public class TourWithManagerAndShowsForCreation : TourWithManagerForCreation
    {
        public ICollection<ShowForCreation> Shows { get; set; }
            = new List<ShowForCreation>();
    }
}
