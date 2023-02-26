using System.ComponentModel.DataAnnotations.Schema;

namespace OfferTask.Models
{
    public class Offer
    {
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public bool IsAvailable { get; set; }
		public string? Url { get; set; }
		public string? Picture { get; set; }
		public string? Artist { get; set; }
		public string? Title { get; set; }
		public int Year { get; set; }
		public string? Description { get; set; }
    }
}