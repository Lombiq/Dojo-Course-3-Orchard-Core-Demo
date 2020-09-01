using DojoCourse.Module.Indexes;
using DojoCourse.Module.Models;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using OrchardCore.Modules;
using System.Linq;
using System.Threading.Tasks;
using YesSql;

namespace DojoCourse.Module.Controllers
{
    public class PersonController : Controller
    {
        private readonly ISession _session;
        private readonly IContentManager _contentManager;
        private readonly IClock _clock;

        public PersonController(ISession session, IContentManager contentManager, IClock clock)
        {
            _session = session;
            _contentManager = contentManager;
            _clock = clock;
        }


        [Route("PersonList")]
        public async Task<string> List()
        {
            var threshold = _clock.UtcNow.AddYears(-40);

            var personPages = await _session
                .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "PersonPage")
                .With<PersonPartIndex>(personPartIndex => personPartIndex.BirthDateUtc > threshold)
                .ListAsync();

            foreach (var personPage in personPages)
            {
                await _contentManager.LoadAsync(personPage);
            }

            return string.Join(", ", personPages.Select(personPage => personPage.As<PersonPart>().Name));
        }
    }
}
