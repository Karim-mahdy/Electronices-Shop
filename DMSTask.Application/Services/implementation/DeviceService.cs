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
    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork unitOfWork;

        public DeviceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public bool CheckDeviceExists(Device device)
        {
            return unitOfWork.DeviceRepository.Any(x => x.DeviceName.ToLower() == device.DeviceName.ToLower() && x.DeviceCategoryID == device.DeviceCategoryID);
        }

        public void Create(Device device)
        {
            unitOfWork.DeviceRepository.Add(device);
            unitOfWork.Save();
        }

        public IEnumerable<Device> GetAllDevicies()
        {
          return unitOfWork.DeviceRepository.GetAll(includeProperties: "DeviceCategory");
        }

        public Device GetDeviceById(int id)
        {
            return unitOfWork.DeviceRepository.Get(x=>x.ID == id, includeProperties: "DeviceCategory");
        }

        public void Remove(Device device)
        {  
                unitOfWork.DeviceRepository.Remove(device);
                unitOfWork.Save();
        }

        public void Update(Device device)
        {
            unitOfWork.DeviceRepository.Update(device);
            unitOfWork.Save();
        }
    }
}
