using DMS_Task.ViewModels;
using DMSTask.Application.Interfaces;
using DMSTask.Application.Services.Interfaces;
using DMSTask.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMS_Task.Controllers
{
    public class PropertyItemController : Controller
    {

        private readonly IPropertyItemService propertyItemService;
        private readonly IDeviceCategoryService deviceCategoryService;

        public PropertyItemController(IPropertyItemService propertyItemService, IDeviceCategoryService deviceCategoryService)
        {
            this.propertyItemService = propertyItemService;
            this.deviceCategoryService = deviceCategoryService;
        }
        public IActionResult Index()
        {
            var propertyItems = propertyItemService.GetAllPropertyItem();
            var properties = new List<PropertyDeviceCategoryVM>();

            foreach (var property in propertyItems)
            {
                var prop = new PropertyDeviceCategoryVM
                {
                    Id = property.ID,
                    CategoryName = property.DeviceCategory.CategoryName,
                    Name = property.PropertyDescription,

                };
                properties.Add(prop);
            }

            return View(properties);
        }
        public IEnumerable<SelectListItem> GetGategories()
        {
            return deviceCategoryService.GetAllCategories().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.ID.ToString()
            });
        }

        public IActionResult Create()
        {

            var model = new PropertyDeviceCategoryVM
            {
                Gategories = GetGategories()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PropertyDeviceCategoryVM model)
        {
            if (ModelState.IsValid)
            {
                var propertyItem = new PropertyItem
                {
                    PropertyDescription = model.Name,
                    DeviceCategoryID = model.CategoryID
                };
                if (propertyItemService.CheckPropertyItemExists(propertyItem))
                {
                    model.Gategories = GetGategories();
                    return View(model);
                }
                propertyItemService.Create(propertyItem);
                return RedirectToAction(nameof(Index));
            }
            model.Gategories = GetGategories();
            return View(model);

        }
        public IActionResult Edit(int id)
        {

            var propertyItem = propertyItemService.GetPropertyItemById(id);
            PropertyDeviceCategoryVM model = new PropertyDeviceCategoryVM();
            if (propertyItem != null)
            {
                model = new PropertyDeviceCategoryVM
                {
                    Id = id,
                    CategoryName = propertyItem.DeviceCategory.CategoryName,
                    Name = propertyItem.PropertyDescription,
                    CategoryID = propertyItem.DeviceCategoryID,
                    Gategories = GetGategories()
                };
                model.Gategories = GetGategories();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PropertyDeviceCategoryVM model)
        {
            if (ModelState.IsValid)
            {
                var propertyItem = propertyItemService.GetPropertyItemById(model.Id);

                propertyItem.PropertyDescription = model.Name;
                propertyItem.DeviceCategoryID = model.CategoryID;

                if (propertyItemService.GetAllPropertyItem().Any(
                    x => x.DeviceCategoryID == propertyItem.DeviceCategoryID &&
                    x.PropertyDescription.ToLower() == propertyItem.PropertyDescription.ToLower() &&
                    x.ID != propertyItem.ID
                    ))
                {
                    model.Gategories = GetGategories();
                    return View(model);
                }
                propertyItemService.Update(propertyItem);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var propertyItem = propertyItemService.GetPropertyItemById(id);
            if (propertyItem != null)
            {
                propertyItemService.Remove(propertyItem);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
