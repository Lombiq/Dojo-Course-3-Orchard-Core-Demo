using DojoCourse.Module.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.Contents;
using System.Threading.Tasks;

namespace DojoCourse.Module.Controllers
{
    //[Admin]
    public class AdminController : Controller
    {
        private readonly IContentManager _contentManager;
        private readonly IAuthorizationService _authorizationService;


        public AdminController(IContentManager contentManager, IAuthorizationService authorizationService)
        {
            _contentManager = contentManager;
            _authorizationService = authorizationService;
        }


        public string Index()
        {
            return "OK";
        }

        public async Task<string> ContentAuthorization()
        {
            var personPage = await _contentManager.NewAsync("PersonPage");

            var isAuthorized = await _authorizationService
                .AuthorizeAsync(User, CommonPermissions.EditContent, personPage);

            return $"Is authorized? {isAuthorized}";
        }

        public async Task<string> CustomAuthorization()
        {
            var isAuthorized = await _authorizationService
                .AuthorizeAsync(User, PersonPagePermissions.ManagePersonPages);

            return $"Is authorized? {isAuthorized}";
        }
    }
}
