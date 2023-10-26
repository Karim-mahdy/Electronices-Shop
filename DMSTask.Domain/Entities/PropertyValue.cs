using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Domain.Entities
{
    public  class PropertyValue
    {
        [Key]
        public int ID { get; set; }


        [ForeignKey("Device")]
        public int DeviceID { get; set; }

        public Device Device { get; set; }

        [ForeignKey("PropertyItem")]
        public int PropertyItemID { get; set; }

        public PropertyItem PropertyItem { get; set; }

        [MaxLength(255)]
        public string Value { get; set; }
    }
}
