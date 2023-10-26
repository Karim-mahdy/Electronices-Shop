using DMSTask.Application.Interfaces;
using DMSTask.Application.Services.Interfaces;
using DMSTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Application.Services.implementation
{
    public class DeviceCategoryService : IDeviceCategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public DeviceCategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool CheckCategoryExists(DeviceCategory category)
        {
            return unitOfWork.DeviceCategoryRepository.Any(x => x.CategoryName.ToLower() == category.CategoryName.ToLower());
        }

        public void Create(DeviceCategory category)
        {
             
           unitOfWork.DeviceCategoryRepository.Add(category);
            unitOfWork.Save();
        }

        public IEnumerable<DeviceCategory> GetAllCategories()
        {
           return unitOfWork.DeviceCategoryRepository.GetAll();
        }

        public DeviceCategory GetCategoryById(int id)
        {
            return unitOfWork.DeviceCategoryRepository.Get(x=>x.ID == id);
        }

        public void Update(DeviceCategory category)
        {
            unitOfWork.DeviceCategoryRepository.Update(category);
            unitOfWork.Save();
        }

        public void Remove (DeviceCategory category)
        {
            unitOfWork.DeviceCategoryRepository.Remove(category);
            unitOfWork.Save();
        }

    }
}
