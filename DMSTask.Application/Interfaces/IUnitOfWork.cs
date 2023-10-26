using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IDeviceRepository DeviceRepository { get; }

        IDeviceCategoryRepository DeviceCategoryRepository { get; }
        IPropertyItemRepository PropertyItemRepository { get; }

        IPropertyValueRepository PropertyValueRepository { get; }

        int Save();
    }
}
