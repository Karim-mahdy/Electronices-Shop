using DMS_Task.ViewModels;
using DMSTask.Application.Services.implementation;
using DMSTask.Application.Services.Interfaces;
using DMSTask.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMS_Task.Controllers
{
    public class DevcieController : Controller
    {
        private readonly IDeviceService deviceService;
        private readonly IDeviceCategoryService deviceCategoryService;

        public DevcieController(IDeviceService deviceService, IDeviceCategoryService deviceCategoryService)
        {
            this.deviceService = deviceService;
            this.deviceCategoryService = deviceCategoryService;
        }
        public IActionResult Index()
        {
            var model = new List<DeviceProperteiseValuesVM>();
            var devices = deviceService.GetAllDevicies();

            foreach (var device in devices)
            {
                var deviceModel = new DeviceProperteiseValuesVM
                {
                    ID = device.ID,
                    DeviceName = device.DeviceName,
                    CategoryName = device.DeviceCategory.CategoryName,
                    AcquisitionDate = device.AcquisitionDate,
                    Memo = device.Memo
                };
                model.Add(deviceModel);
            }

            return View(model);
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
            var deviceModel = new DeviceProperteiseValuesVM
            {
                Gategories = GetGategories()
            };
            return View(deviceModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceProperteiseValuesVM model)
        {
            if (ModelState.IsValid)
            {
                var device = new Device
                {
                    DeviceName = model.DeviceName,
                    AcquisitionDate = model.AcquisitionDate,
                    DeviceCategoryID = model.CategoryId,
                    Memo = model.Memo,
                };
                if (deviceService.CheckDeviceExists(device))
                {
                    model.Gategories = GetGategories();
                    return View(model);
                }
                deviceService.Create(device);
            
                model.ID = device.ID;
                model.Gategories = GetGategories();
                model.CategoryId = device.DeviceCategoryID;
                
                return View(model);
            }
            model.Gategories = GetGategories();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var device = deviceService.GetDeviceById(id);

            if (device != null)
            {
                var deviceModel = new DeviceProperteiseValuesVM
                {
                    ID = device.ID,
                    DeviceName = device.DeviceName,
                    AcquisitionDate = device.AcquisitionDate,
                    Memo = device.Memo,
                    CategoryId = device.DeviceCategoryID,
                    Gategories = GetGategories()

            };
                return View(deviceModel);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DeviceProperteiseValuesVM model)
        {
            var device = deviceService.GetDeviceById(model.ID);
            if (device != null && ModelState.IsValid)
            {
                if (deviceService.GetAllDevicies().Any(
                    x => x.DeviceName.ToLower() == model.DeviceName.ToLower() &&
                    x.DeviceCategoryID == model.CategoryId &&
                    x.ID != model.ID
                    ))
                {
                    model.Gategories = GetGategories();
                    return View(model);
                }
                device.DeviceName = model.DeviceName;
                device.DeviceCategoryID = model.CategoryId;
                device.Memo = model.Memo;
                device.AcquisitionDate = model.AcquisitionDate;

                deviceService.Update(device);
                return RedirectToAction(nameof(Index));
            }
            model.Gategories = GetGategories();
            return View(model);
        }

        public IActionResult Remove(int id)
        {
            var device = deviceService.GetDeviceById(id);
            deviceService.Remove(device);
            return RedirectToAction(nameof(Index));
        }


     


    }
}
