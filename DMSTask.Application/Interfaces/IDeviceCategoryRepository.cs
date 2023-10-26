using DMSTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Application.Interfaces
{
    public interface IDeviceCategoryRepository : IRepository<DeviceCategory>
    {
        public void Update(DeviceCategory entity);
    }
}
