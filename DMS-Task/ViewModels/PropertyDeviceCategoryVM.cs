using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DMS_Task.ViewModels
{
    public class PropertyDeviceCategoryVM
    {
        public int Id { get; set; }

         
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
 
        public string Name { get; set; }

        public IEnumerable<SelectListItem>? Gategories { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
