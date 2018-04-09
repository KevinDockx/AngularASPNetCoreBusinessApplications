using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManagement.API.Dtos;
using TourManagement.API.Services;

namespace TourManagement.API.Controllers
{
    [Route("api/bands")]
    [Authorize]
    public class BandsController : Controller
    {
        private readonly ITourManagementRepository _tourManagementRepository;

        public BandsController(ITourManagementRepository tourManagementRepository)
        {
            _tourManagementRepository = tourManagementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBands()
        {
            var bandsFromRepo = await _tourManagementRepository.GetBands();

            var bands = Mapper.Map<IEnumerable<Band>>(bandsFromRepo);

            return Ok(bands);
        }
    }
}
