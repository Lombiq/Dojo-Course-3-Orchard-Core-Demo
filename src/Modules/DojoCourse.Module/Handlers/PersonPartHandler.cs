using DojoCourse.Module.Models;
using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;

namespace DojoCourse.Module.Handlers
{
    public class PersonPartHandler : ContentPartHandler<PersonPart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, PersonPart instance)
        {
            context.ContentItem.DisplayText = instance.Name;
            return Task.CompletedTask;
        }
    }
}
