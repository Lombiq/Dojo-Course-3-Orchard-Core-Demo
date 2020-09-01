using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.Users.Events;
using System;
using System.Threading.Tasks;

namespace DojoCourse.Module.Events
{
    public class LoginGreeting : ILoginFormEvent
    {
        private readonly INotifier _notifier;
        private readonly IHtmlLocalizer T;


        public LoginGreeting(INotifier notifier, IHtmlLocalizer<LoginGreeting> htmlLocalizer)
        {
            _notifier = notifier;
            T = htmlLocalizer;
        }


        public Task LoggedInAsync(string userName)
        {
            _notifier.Success(T["Hi {0}!", userName]);
            return Task.CompletedTask;
        }

        public Task LoggingInAsync(string userName, Action<string, string> reportError) => Task.CompletedTask;

        public Task LoggingInFailedAsync(string userName) => Task.CompletedTask;
    }
}
