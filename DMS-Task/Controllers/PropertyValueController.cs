using DMS_Task.ViewModels;
using DMSTask.Application.Services.Interfaces;
using DMSTask.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DMS_Task.Controllers
{
    public class PropertyValueController : Controller
    {
        private readonly IPropertyValueService propertyValueService;
        private readonly IDeviceCategoryService deviceCategoryService;

        public PropertyValueController(IPropertyValueService propertyValueService,IDeviceCategoryService deviceCategoryService)
        {
            this.propertyValueService = propertyValueService;
            this.deviceCategoryService = deviceCategoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int categotyId ,int devcie)
        {
            var category = deviceCategoryService.GetCategoryById(categotyId);
            var propertyValue = new PropertyValuesVM()
            {
                DeviceCategory = category,
                deviceId = devcie
            };
            return PartialView("_PropertyValuesPartial", propertyValue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PropertyValue propertyValue)
        {
            if (ModelState.IsValid)
            {
                propertyValueService.Create(propertyValue);
                return RedirectToAction("Index",nameof(DevcieController));
          
            }
            // If ModelState is not valid, return the partial view with validation errors
            return PartialView("_PropertyValuesPartial", propertyValue);
        }
    }
}
