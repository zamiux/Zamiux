using Microsoft.EntityFrameworkCore;
using Zamiux.Web.Entities.Ability;
using Zamiux.Web.Entities.Authorization;
using Zamiux.Web.Entities.Contact;
using Zamiux.Web.Entities.Resume;
using Zamiux.Web.Entities.Services;
using Zamiux.Web.Entities.Social;
using Zamiux.Web.Entities.User;
using Zamiux.Web.Entities.Works;

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
        public DbSet<UserSocial> UserSocials { get; set; }
        public DbSet<ContactMsg> ContactMsgs { get; set; }
        public DbSet<ResumeDl> resumeDls { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

    }
}
 