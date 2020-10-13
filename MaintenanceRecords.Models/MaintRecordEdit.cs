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
    public class MaintRecordEdit
    {
        public int RecordId { get; set; }

        [ForeignKey(nameof(MaintItem))]
        public int ItemId { get; set; }
        public virtual MaintItem MaintItem { get; set; }

        [Required]
        [Display(Name = "Item Notes")]
        public string RecordText { get; set; }

        [Display(Name = "Record Date")]
        public DateTime RecordDate { get; set; }
    }
}
