using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceRecords.Data
{
    public class MaintRecord
    {
        [Key]
        public int RecordId { get; set; }

        [ForeignKey(nameof(MaintItem))]
        public int ItemId { get; set; }
        public virtual MaintItem MaintItem { get; set; }

        [Required]
        [Display(Name = "Item notes")]
        public string RecordText { get; set; }

        public DateTime RecordDate { get; set; }

        //public DateTime RecordDate
        //{
        //    get { return DateTime.Now; }
        //    set { }
        //}




    }
}
