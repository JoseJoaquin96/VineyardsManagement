using System.Diagnostics;

namespace VineyardsManagement.Models
{
    public class Parcels
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int VineyardId { get; set; }
        public int GrapeId { get; set; }
        public int YearPlanted { get; set; }
        public int Area { get; set; }
        public virtual Managers Manager { get; set; } = null!;
        public virtual Vineyards Vineyard { get; set; } = null!;
        public virtual Grapes Grape { get; set; } = null!;
    }
}
