using DMSTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Application.Services.Interfaces
{
    public interface IDeviceService
    {
        IEnumerable<Device> GetAllDevicies();
        Device GetDeviceById(int id);
        void Create(Device device);
        void Update(Device device);

        bool CheckDeviceExists(Device device);
        void Remove(Device device);
    }
}
