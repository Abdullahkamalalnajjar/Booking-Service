

namespace Project.EF.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            // Default Data
            builder.HasData([
             new ApplicationRole{
                 Id = DefaultRoles.AdminRoleId,
                 Name = DefaultRoles.Admin,
                 NormalizedName = DefaultRoles.Admin.ToUpper(),
                 ConcurrencyStamp = DefaultRoles.AdminRoleConcurrencyStamp,
             },
             new ApplicationRole { 
                 Id = DefaultRoles.ServiceProviderRoleId,
                 Name = DefaultRoles.ServiceProvider,
                 NormalizedName = DefaultRoles.ServiceProvider.ToUpper(),
                 ConcurrencyStamp = DefaultRoles.ServiceProviderRoleConcurrencyStamp,
                 IsDefualt = false,
             },
             new ApplicationRole{
                 Id = DefaultRoles.MemberRoleId,
                 Name = DefaultRoles.Member,
                 NormalizedName = DefaultRoles.Member.ToUpper(),
                 ConcurrencyStamp = DefaultRoles.MemberRoleConcurrencyStamp,
                 IsDefualt = true,
             }
             ]);
        }
    }
}
