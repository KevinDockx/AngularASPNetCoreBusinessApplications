using System.Collections.Generic;

namespace TourManagement.API.Dtos
{
    public class TourWithShows : Tour
    {
        public ICollection<Show> Shows { get; set; }
            = new List<Show>();
    }
}
