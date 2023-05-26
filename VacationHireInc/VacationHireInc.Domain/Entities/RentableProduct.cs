using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationHireInc.Domain.Entities
{
	public class RentableProduct
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ProductType { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}

