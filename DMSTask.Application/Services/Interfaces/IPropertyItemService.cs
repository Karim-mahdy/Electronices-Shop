using DMSTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Application.Services.Interfaces
{
    public interface IPropertyItemService
    {
        IEnumerable<PropertyItem> GetAllPropertyItem();
        PropertyItem GetPropertyItemById(int id);
        void Create(PropertyItem propertyItem);
        void Update(PropertyItem propertyItem);

        bool CheckPropertyItemExists(PropertyItem propertyItem);
        void Remove(PropertyItem propertyItem);
    }
}
