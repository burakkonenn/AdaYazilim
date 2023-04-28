using Domain.Entities.Common;


namespace Domain.Entities
{
    public class Vagon : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int FullSeats { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
    }
}
