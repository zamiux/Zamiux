using Microsoft.EntityFrameworkCore;

namespace Zamiux.Web.Context
{
	public class ZamiuxDbContext:DbContext
	{
		public ZamiuxDbContext(DbContextOptions<ZamiuxDbContext> options) :base(options)
		{ }

		// DbSet
       
    }
}
 