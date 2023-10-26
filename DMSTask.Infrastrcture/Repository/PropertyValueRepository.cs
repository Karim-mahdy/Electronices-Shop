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
    public class PropertyValueRepository : Repository<PropertyValue>, IPropertyValueRepository
    {
        private readonly ApplicationDbContext context;

        public PropertyValueRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public void Update(PropertyValue propertyValue)
        {
            context.Update(propertyValue);
        }
    }
}
