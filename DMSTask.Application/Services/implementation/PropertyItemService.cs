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
    public class PropertyItemService : IPropertyItemService
    {
        private readonly IUnitOfWork unitOfWork;

        public PropertyItemService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public bool CheckPropertyItemExists(PropertyItem propertyItem)
        {
            return unitOfWork.PropertyItemRepository.Any(x=>x.PropertyDescription.ToLower() == propertyItem.PropertyDescription.ToLower());

        }

        public IEnumerable<PropertyItem> GetAllPropertyItem()
        {
            return unitOfWork.PropertyItemRepository.GetAll(includeProperties:"DeviceCategory");
        }
        public PropertyItem GetPropertyItemById(int id)
        {
            return unitOfWork.PropertyItemRepository.Get(x=>x.ID == id,includeProperties: "DeviceCategory");
        }
        public void Create(PropertyItem propertyItem)
        {
            unitOfWork.PropertyItemRepository.Add(propertyItem);
            unitOfWork.Save();
        }

        public void Update(PropertyItem propertyItem)
        {
            unitOfWork.PropertyItemRepository.Update(propertyItem);
            unitOfWork.Save();
        }

        public void Remove(PropertyItem propertyItem)
        {
            unitOfWork.PropertyItemRepository.Remove(propertyItem);
            unitOfWork.Save();
        }
    }
}
