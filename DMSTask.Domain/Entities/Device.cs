using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DMSTask.Domain.Entities
{
    public class Device
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "DeviceName should be at most 50 characters.")]
        [MinLength(3, ErrorMessage = "DeviceName should be at least 3 characters.")]
        [DisplayName("Device Name")]
        public string DeviceName { get; set; }

       

        [Required]
        public DateTime AcquisitionDate { get; set; }

        [StringLength(500, ErrorMessage = "Memo should be at most 500 characters.")]
        public string Memo { get; set; }

        [Required]
        [ForeignKey("DeviceCategory")]
        public int DeviceCategoryID { get; set; }
        public DeviceCategory DeviceCategory { get; set; }
        public ICollection<PropertyValue> PropertyValues { get; set; }
    }
}
