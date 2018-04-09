using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.API.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string UserId { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        
        public UserInfoService(IHttpContextAccessor httpContextAccessor)
        {
            // service is scoped, created once for each request => we only need
            // to fetch the info in the constructor
            _httpContextAccessor = httpContextAccessor 
                ?? throw new ArgumentNullException(nameof(httpContextAccessor));

            var currentContext = _httpContextAccessor.HttpContext;
            if (currentContext == null || !currentContext.User.Identity.IsAuthenticated)
            {
                UserId = "n/a";
                FirstName = "n/a";
                LastName = "n/a";
                return;
            }
            
            UserId = (currentContext.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value) ?? "n/a";
            FirstName = (currentContext.User.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value) ?? "n/a";
            LastName = (currentContext.User.Claims.FirstOrDefault(c => c.Type == "family_name")?.Value) ?? "n/a";
        }
    }
}
