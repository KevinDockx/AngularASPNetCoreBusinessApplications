using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.API.Helpers
{
    public class CustomizedValidationError
    {
        public string ValidatorKey { get; private set; }
        public string Message { get; private set; }

        public CustomizedValidationError(string message, string validatorKey = "")
        {
            ValidatorKey = validatorKey;
            Message = message;
        }
    }

}
