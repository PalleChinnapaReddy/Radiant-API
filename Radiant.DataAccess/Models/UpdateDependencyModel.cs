namespace Radiant.DataAccess.Models
{
    public class UpdateDependencyModel
    {
        public string Attribute { get; set; }
        public long CurrentValue { get; set; }
        public long NewValue { get; set; }
        public bool IsDeleted { get; set; }
    }
}
