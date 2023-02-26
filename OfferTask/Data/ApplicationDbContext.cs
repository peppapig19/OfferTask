using Microsoft.EntityFrameworkCore;
using OfferTask.Models;

namespace OfferTask.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Offer> Offers { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
	}
}