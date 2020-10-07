using MaintenanceRecords.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceRecords.Models
{
    public class MaintItemListItem
    {
        public int ItemId { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        public int? Year { get; set; }
        public string Make { get; set; }

        [Display(Name = "Model")]
        public string ItemModel { get; set; }

        [Display(Name = "Misc Info")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string MiscInfo { get; set; }

        [ForeignKey(nameof(ItemLocation))]
        public int LocationId { get; set; }
        public virtual ItemLocation ItemLocation { get; set; }
    }
}
