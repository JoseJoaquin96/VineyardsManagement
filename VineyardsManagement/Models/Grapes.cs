namespace VineyardsManagement.Models
{
    public class Grapes
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual List<Parcels> Parcels { get; set; }
    }
}
