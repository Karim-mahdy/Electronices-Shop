using DMSTask.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace DMS_Task.ViewModels
{
    public class DeviceProperteiseValuesVM
    {
        public int ID { get; set; }

        [DisplayName("Device Name")]
        public string DeviceName { get; set; }
        [DisplayName("Acquisition Date")]
        public DateTime AcquisitionDate { get; set; }
        public string Memo { get; set; }

        public int CategoryId { get; set; }

        
        public string? CategoryName { get; set; }
        public IEnumerable<SelectListItem> Gategories { get; set; } = new List<SelectListItem>();


    }
}
