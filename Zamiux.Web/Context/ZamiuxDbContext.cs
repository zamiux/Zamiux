using Microsoft.EntityFrameworkCore;
using Zamiux.Web.Entities.Ability;
using Zamiux.Web.Entities.Contact;
using Zamiux.Web.Entities.Services;
using Zamiux.Web.Entities.User;

namespace Zamiux.Web.Context
{
	public class ZamiuxDbContext:DbContext
	{
		public ZamiuxDbContext(DbContextOptions<ZamiuxDbContext> options) :base(options)
		{ }

        // DbSet
        #region DbSet
        public DbSet<User> users { get; set; }
        public DbSet<UserContent> userContents { get; set; }
        public DbSet<UserAbility> userAbilities { get; set; }
        public DbSet<UserIntro> userIntros { get; set; }
        public DbSet<UserService> UserServices { get; set; }
        public DbSet<InfoContact> InfoContacts { get; set; }
        #endregion

    }
}
 