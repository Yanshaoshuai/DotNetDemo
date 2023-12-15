using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace DotNetDemo.WebApi.Utility.Route
{
    /// <summary>
    /// 全局路由配置
    /// </summary>
    public class RouteConversion : IApplicationModelConvention
    {

        private readonly AttributeRouteModel _centralPrefix;

        public RouteConversion(IRouteTemplateProvider routeTemplateProvider)
        {
            _centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        /// <summary>
        /// 根据情况添加路由前缀
        /// </summary>
        void IApplicationModelConvention.Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                //已经标记了RouteAttribute的Controller 在路由的前面添加前缀
                List<SelectorModel> markedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                if (markedSelectors.Any())
                {
                    foreach (var selectorModel in markedSelectors)
                    {
                        selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                            _centralPrefix, selectorModel.AttributeRouteModel);
                    }

                }
                //没有标记RouteAttribute的Controller
                List<SelectorModel> unmarkedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
                if (unmarkedSelectors.Any())
                {
                    foreach (var selectorModel in unmarkedSelectors)
                    {
                        //直接添加前缀
                        selectorModel.AttributeRouteModel = _centralPrefix;
                    }
                }
            }
        }
    }
}
