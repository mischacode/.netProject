namespace NetProject.Entities
{
    public class Disk
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; } // Waiting, Collected
        public int LocationId { get; set; }
        public int ClientId { get; set; }
    }
}
