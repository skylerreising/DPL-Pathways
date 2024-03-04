namespace HomeSearchOrganizer.Models
{
    public class Home
    {
        public long Id { get; set; }
        public string? Address { get; set; }
        public bool IsComplete { get; set; }//viewed
        public double Bedrooms { get; set; }
        public double Bathrooms { get; set; }
        public string? Secret { get; set; }
    }
 
    public class HomeDto
    {
        public long Id { get; set; }
        public string? Address { get; set; }
        public bool IsComplete { get; set; }
        public double Bedrooms { get; set; }
        public double Bathrooms { get; set; }
    }
}
