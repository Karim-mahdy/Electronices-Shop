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
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        private readonly ApplicationDbContext context;

        public DeviceRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public void Update(Device device)
        {
            context.Update(device);
        }
    }
}
