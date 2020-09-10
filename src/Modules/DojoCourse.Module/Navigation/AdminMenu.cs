using DojoCourse.Module.Permissions;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DojoCourse.Module.Navigation
{
    public class AdminMenu : INavigationProvider
    {
        private readonly IStringLocalizer T;


        public AdminMenu(IStringLocalizer<AdminMenu> localizer) => T = localizer;


        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase)) return Task.CompletedTask;

            builder
                .Add(
                    T["Person Page Admin"], 
                    "5", 
                    item => item
                        .Action("CustomAuthorization", "Admin", new { Area = "DojoCourse.Module" })
                        .Permission(PersonPagePermissions.ManagePersonPages));

            return Task.CompletedTask;
        }
    }
}
