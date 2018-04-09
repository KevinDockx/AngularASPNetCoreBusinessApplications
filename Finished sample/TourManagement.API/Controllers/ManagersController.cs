using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManagement.API.Dtos;
using TourManagement.API.Services;

namespace TourManagement.API.Controllers
{
    [Route("api/managers")]
    [Authorize]
    public class ManagersController : Controller
    {
        private readonly ITourManagementRepository _tourManagementRepository;

        public ManagersController(ITourManagementRepository tourManagementRepository)
        {
            _tourManagementRepository = tourManagementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetManagers()
        {
            var managersFromRepo = await _tourManagementRepository.GetManagers();

            var managers = Mapper.Map<IEnumerable<Manager>>(managersFromRepo);

            return Ok(managers);
        }
    }
}
