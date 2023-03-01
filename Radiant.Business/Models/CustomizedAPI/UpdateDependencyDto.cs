namespace Radiant.Business.Models.CustomizedAPI
{
    public class UpdateDependencyDto
    {
        public string Attribute { get; set; }
        public long CurrentValue { get; set; }
        public long NewValue { get; set; }
        public bool IsDeleted { get; set; }
    }
}
