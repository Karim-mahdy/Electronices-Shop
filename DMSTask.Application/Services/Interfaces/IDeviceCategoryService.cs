using DMSTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Application.Services.Interfaces
{
    public  interface IDeviceCategoryService
    {
        IEnumerable<DeviceCategory> GetAllCategories();
        DeviceCategory GetCategoryById(int id);
        void Create(DeviceCategory category);
        void Update(DeviceCategory category);

        bool CheckCategoryExists(DeviceCategory category);
        void Remove(DeviceCategory category);
    }
}
