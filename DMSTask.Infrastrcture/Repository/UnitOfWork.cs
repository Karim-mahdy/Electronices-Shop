using DMSTask.Application.Interfaces;
using DMSTask.Infrastrcture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Infrastrcture.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IDeviceRepository DeviceRepository { get; private set; }

        public IDeviceCategoryRepository DeviceCategoryRepository { get; private set; }

        public IPropertyItemRepository PropertyItemRepository { get; private set; }

        public IPropertyValueRepository PropertyValueRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            DeviceRepository = new DeviceRepository(context);
            DeviceCategoryRepository = new DeviceCategoryRepository(context);
            PropertyItemRepository = new PropertyItemRepository(context);
            PropertyValueRepository = new PropertyValueRepository(context);
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
