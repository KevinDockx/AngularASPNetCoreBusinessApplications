using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManagement.API.Services;

namespace TourManagement.API.Authorization
{
    public class UserMustBeTourManagerRequirementHandler
        : AuthorizationHandler<UserMustBeTourManagerRequirement>
    {
        private readonly ITourManagementRepository _tourManagementRepository;
        private readonly IUserInfoService _userInfoService;

        public UserMustBeTourManagerRequirementHandler(
            ITourManagementRepository tourManagementRepository,
            IUserInfoService userInfoService)
        {
            _tourManagementRepository = tourManagementRepository;
            _userInfoService = userInfoService;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, UserMustBeTourManagerRequirement requirement)
        {
            if (_userInfoService.Role == requirement.Role)
            {
                context.Succeed(requirement);
                return Task.FromResult(0);
            }

            var filterContext = context.Resource as AuthorizationFilterContext;
            if (filterContext == null)
            {
                context.Fail();
                return Task.FromResult(0);
            }

            var tourId = filterContext.RouteData.Values["tourId"].ToString();

            if (!Guid.TryParse(tourId, out Guid tourIdAsGuid))
            {
                context.Fail();
                return Task.FromResult(0);
            }

            if (!Guid.TryParse(_userInfoService.UserId, out Guid userIdAsGuid))
            {
                context.Fail();
                return Task.FromResult(0);
            }


            if (!_tourManagementRepository.IsTourManager(tourIdAsGuid, userIdAsGuid).Result)
            {
                context.Fail();
                return Task.FromResult(0);
            }

            context.Succeed(requirement);
            return Task.FromResult(0);
        }
    }
}
