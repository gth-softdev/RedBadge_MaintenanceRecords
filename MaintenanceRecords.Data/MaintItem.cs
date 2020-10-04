using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceRecords.Data
{
    public class MaintItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string MiscInfo { get; set; }

        [ForeignKey(nameof(ItemLocation))]
        public int LocationId { get; set; }
        public virtual ItemLocation ItemLocation { get; set; }

        //*[Foreign Key] OwnerId

    }
}
