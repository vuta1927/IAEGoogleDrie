using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAEGoogleDrie.Security.Permissions;

namespace ApiServer.Auth
{
    public class PermissionProvider
    {
        public static readonly Permission AdministratorPermissions = new Permission { Name = DrivePermissions.Administrator, DisplayName = "Administrator", Description = "Administrator permission", Category = "ADMIN" };

        public IEnumerable<Permission> GetPermissions()
        {
            return new[]
            {
                AdministratorPermissions,
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Admin group",
                    Permissions = new[] { AdministratorPermissions }
                },
                //new PermissionStereotype
                //{
                //    Name = "Administrator",
                //    Permissions = new []{Page, AdminPermission, ViewMapPermission, EditMapPermission }
                //}
            };
        }
    }
}
