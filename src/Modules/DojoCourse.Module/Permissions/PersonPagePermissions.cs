using OrchardCore.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoCourse.Module.Permissions
{
    public class PersonPagePermissions : IPermissionProvider
    {
        public static readonly Permission ManagePersonPages = 
            new Permission(nameof(ManagePersonPages), "Can manage Person Pages.");


        public Task<IEnumerable<Permission>> GetPermissionsAsync() =>
            Task.FromResult(new[]
            {
                ManagePersonPages,
            }
            .AsEnumerable());

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() =>
            new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManagePersonPages },
                },
            };
    }
}
