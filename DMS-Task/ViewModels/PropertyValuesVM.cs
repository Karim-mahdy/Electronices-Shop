using DMSTask.Domain.Entities;

namespace DMS_Task.ViewModels
{
    public class PropertyValuesVM
    {
    
        public int deviceId { get; set; }
        public DeviceCategory DeviceCategory {  get; set; }
        public List<PropertyValue> PropertyValues { get; set; }
    }
}
