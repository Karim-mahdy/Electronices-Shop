using DMSTask.Application.Interfaces;
using DMSTask.Domain.Entities;
using DMSTask.Infrastrcture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Infrastrcture.Repository
{
    public class DeviceCategoryRepository : Repository<DeviceCategory>, IDeviceCategoryRepository
    {
        private readonly ApplicationDbContext context;

        public DeviceCategoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public void Update(DeviceCategory deviceCategory)
        {
            context.Update(deviceCategory);
        }
    }
}
