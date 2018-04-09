using System.Collections.Generic;

namespace TourManagement.API.Dtos
{
    public class TourWithEstimatedProfitsAndShows : TourWithEstimatedProfits
    {
        public ICollection<Show> Shows { get; set; }
              = new List<Show>();
    }
}
