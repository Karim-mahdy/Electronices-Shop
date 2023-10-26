using DMSTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Application.Services.Interfaces
{
    public interface IPropertyValueService
    {
        IEnumerable<PropertyValue> GetAllPropertyValue();
        PropertyValue GetPropertyValueById(int id);
        void Create(PropertyValue propertyValue);
        void Update(PropertyValue propertyValue);
        //bool CheckPropertyValueExists(PropertyValue propertyValue);
        //void Remove(PropertyValue propertyValue);
    }
}
