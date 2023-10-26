using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Domain.Entities
{
    public class DeviceCategory
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "Category Name should be at most 50 characters.")]
        [MinLength(3, ErrorMessage = "Category Name should be at least 3 characters.")]
        [DisplayName("Category Name")]
        public required string CategoryName { get; set; }
        public ICollection<PropertyItem>? PropertyItems { get; set; }

        public ICollection<Device>? Devices { get; set; }
    }
}
