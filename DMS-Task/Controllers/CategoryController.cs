using DMSTask.Application.Services.Interfaces;
using DMSTask.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DMS_Task.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IDeviceCategoryService deviceCategoryService;

        public CategoryController(IDeviceCategoryService deviceCategoryService)
        {
            this.deviceCategoryService = deviceCategoryService;
        }
        public IActionResult Index()
        {
          var categories = deviceCategoryService.GetAllCategories();
            if (categories != null)
            {
                return View(categories);
            }
           return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceCategory category)
        {
            if (ModelState.IsValid)
            {
                if (deviceCategoryService.CheckCategoryExists(category) != true)
                {
                    deviceCategoryService.Create(category);
                    return View(category);
                }
               
            }
            return View(category);
        }

        public IActionResult Update(int id)
        {
            var category = deviceCategoryService.GetCategoryById(id);
            if (category != null)
            {
                return View(category);

            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(DeviceCategory category)
        {
            if (ModelState.IsValid)
            {
                if (deviceCategoryService.GetAllCategories().Any(x=>x.CategoryName.ToLower() == category.CategoryName.ToLower() && x.ID != category.ID))
                {
                    // can't update device category with the same category name
                    return View(category);
                }
                deviceCategoryService.Update(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }

        public IActionResult Delete(int id)
        {
            var category = deviceCategoryService.GetCategoryById(id);
            if (category != null)
            {
                deviceCategoryService.Remove(category);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
