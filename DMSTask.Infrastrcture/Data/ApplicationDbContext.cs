using DMSTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSTask.Infrastrcture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Device> Devices { get; set; }

        public virtual DbSet<DeviceCategory> DeviceCategories { get; set; }

        public  virtual DbSet<PropertyItem> PropertyItems { get; set; }

        public virtual DbSet<PropertyValue> PropertyValues { get; set; }


    }
}
