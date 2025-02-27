namespace VineyardsManagement.Models
{
    public class Managers
    {
        public int Id { get; set; }
        public string TaxNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public virtual List<Parcels> Parcels { get; set; }
        public virtual Vineyards Vineyard { get; set; }

    }
}
