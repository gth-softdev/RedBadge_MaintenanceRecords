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
    public class MaintRecordCreate
    {
        [ForeignKey(nameof(MaintItem))]
        public int ItemId { get; set; }
        public virtual MaintItem MaintItem { get; set; }

        //private DateTime _returnDate = DateTime.MinValue;
        [Display(Name = "Date")]
        //public DateTime RecordDate
        //{
        //    get
        //    {
        //        return (_returnDate == DateTime.MinValue) ? DateTime.Now : _returnDate;
        //    }
        //    set { _returnDate = value; }
        //}
        public DateTime RecordDate { get { return DateTime.Now; } }

        [Required]
        [Display(Name = "Item notes")]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string RecordText { get; set; }

    }
}
