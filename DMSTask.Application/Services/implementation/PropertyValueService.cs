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
    public class PropertyValueService : IPropertyValueService
    {
        private readonly IUnitOfWork unitOfWork;

        public PropertyValueService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Create(PropertyValue propertyValue)
        {
            unitOfWork.PropertyValueRepository.Add(propertyValue);
            unitOfWork.Save();
        }

        public IEnumerable<PropertyValue> GetAllPropertyValue()
        {
           return unitOfWork.PropertyValueRepository.GetAll();
        }

        public PropertyValue GetPropertyValueById(int id)
        {
            return unitOfWork.PropertyValueRepository.Get(x=>x.ID==id);
        }

        public void Update(PropertyValue propertyValue)
        {
            unitOfWork.PropertyValueRepository.Update(propertyValue);
            unitOfWork.Save();
        }
    }
}
