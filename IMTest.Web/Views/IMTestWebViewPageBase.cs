using Abp.Web.Mvc.Views;

namespace IMTest.Web.Views
{
    public abstract class IMTestWebViewPageBase : IMTestWebViewPageBase<dynamic>
    {

    }

    public abstract class IMTestWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected IMTestWebViewPageBase()
        {
            LocalizationSourceName = IMTestConsts.LocalizationSourceName;
        }
    }
}