using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Layout;
using System.Threading.Tasks;

namespace DojoCourse.Module.Filters
{
    public class ShapeInjectingFilter : IAsyncResultFilter
    {
        private readonly ILayoutAccessor _layoutAccessor;
        private readonly IShapeFactory _shapeFactory;


        public ShapeInjectingFilter(ILayoutAccessor layoutAccessor, IShapeFactory shapeFactory)
        {
            _layoutAccessor = layoutAccessor;
            _shapeFactory = shapeFactory;
        }


        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!(context.Result is ViewResult || context.Result is PageResult))
            {
                await next();
                return;
            }

            dynamic layout = await _layoutAccessor.GetLayoutAsync();

            var contentZone = layout.Zones["Content"];
            contentZone.Add(await _shapeFactory.New.LayoutInjectectedShape());

            await next();
        }
    }
}
