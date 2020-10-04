using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceRecords.Data
{
    public class ItemLocation
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Item Location")]
        public string SiteName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        
        public string City { get; set; }
        public string State { get; set; }
    }
}
