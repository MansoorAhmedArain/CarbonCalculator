using Microsoft.AspNetCore.Mvc.Rendering;

namespace WTechAuth.Helper
{
    public static class HtmlHelpers // Make the class static
    {
        public static string IsActive(this IHtmlHelper htmlHelper, string controller = null, string action = null)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeController = (string)routeData.Values["controller"];

            // Log values for debugging
            Console.WriteLine($"Controller: {routeController}, Action: {routeAction}");

            bool isActive = (controller == null || controller == routeController) &&
                            (action == null || action == routeAction);

            return isActive ? "active" : "";
        }

    }
}
