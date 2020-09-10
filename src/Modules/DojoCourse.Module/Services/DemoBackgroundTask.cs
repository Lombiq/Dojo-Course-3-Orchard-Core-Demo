using Microsoft.Extensions.DependencyInjection;
using OrchardCore.BackgroundTasks;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DojoCourse.Module.Services
{
    [BackgroundTask(Schedule = "*/1 * * * *", Description = "Just a demo background task.")]
    public class DemoBackgroundTask : IBackgroundTask
    {
        public Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            //var contentManager = serviceProvider.GetRequiredService<IContentManager>();
            Debugger.Break();
            return Task.CompletedTask;
        }
    }
}
