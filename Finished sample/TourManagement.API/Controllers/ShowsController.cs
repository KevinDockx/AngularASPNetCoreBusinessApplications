using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManagement.API.Dtos;
using TourManagement.API.Services;

namespace TourManagement.API.Controllers
{
    [Route("api/tours/{tourId}/shows")]
    [Authorize]

    public class ShowsController : Controller
    {
        private readonly ITourManagementRepository _tourManagementRepository;

        public ShowsController(ITourManagementRepository tourManagementRepository)
        {
            _tourManagementRepository = tourManagementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetShows(Guid tourId)
        {
            var tourFromRepo = await _tourManagementRepository.GetTour(tourId, true);

            if (!(await _tourManagementRepository.TourExists(tourId)))
            {
                return NotFound();
            }

            var showsFromRepo = await _tourManagementRepository.GetShows(tourId);

            var shows = Mapper.Map<IEnumerable<Show>>(showsFromRepo);
            return Ok(shows);
        }
    }
}
