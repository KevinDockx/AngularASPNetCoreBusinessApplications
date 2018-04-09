using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.API.Dtos
{
    public abstract class TourAbstractBase : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "required|Title is required.")]
        [MaxLength(200, ErrorMessage = "maxLength|Title is too long.")]
        public string Title { get; set; }

        [MaxLength(2000, ErrorMessage = "maxLength|Description is too long.")]
        public virtual string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "required|The start date is required.")]
        public DateTimeOffset StartDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "required|The end date is required.")]
        public DateTimeOffset EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!(StartDate < EndDate))
            {
                yield return new ValidationResult(
                "startDateBeforeEndDate|The start date should be smaller than the end date.",
                new[] { "Tour" });
            }

        }
    }
}
