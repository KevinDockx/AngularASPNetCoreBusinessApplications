using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourManagement.API.Entities
{
    public class Tour : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TourId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public decimal EstimatedProfits { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        public DateTimeOffset EndDate { get; set; }

        [Required]
        public Guid BandId { get; set; }

        [Required]
        public Band Band { get; set; }

        public Guid ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public Manager Manager { get; set; }

        public ICollection<Show> Shows { get; set; } = new List<Show>();
    }
}
