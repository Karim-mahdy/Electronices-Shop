using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Domain.Entities
{
    public class PropertyItem
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Property Description should be at most 50 characters.")]
        [DisplayName("Property Description")]
        public required string PropertyDescription { get; set; }

        public int DeviceCategoryID { get; set; }

        [ForeignKey("DeviceCategoryID")]
        public DeviceCategory DeviceCategory { get; set; }

    }
}
