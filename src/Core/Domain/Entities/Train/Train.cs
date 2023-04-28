using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Train : BaseEntity
    {
        public string Name { get; set; }
        public List<Vagon> Vagon { get; set; }
    }
}
