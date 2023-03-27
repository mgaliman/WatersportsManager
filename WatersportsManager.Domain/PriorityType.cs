using WatersportsManager.Domain.Base;

namespace WatersportsManager.Domain
{
    public class PriorityType : BaseTypeEntity
    {
        public ICollection<Report> Reports { get; set; } = new List<Report>();

    }
}
