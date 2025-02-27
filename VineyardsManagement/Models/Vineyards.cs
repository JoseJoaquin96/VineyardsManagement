namespace VineyardsManagement.Models
{
    public class Vineyards
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual List<Managers> Managers { get; set; }
        public virtual List<Parcels> Parcels { get; set; }
    }
}
