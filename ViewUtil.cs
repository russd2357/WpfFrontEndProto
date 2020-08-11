using System;
using WpfFrontEndProto.Views;
using SimpleInjector;


namespace WpfFrontEndProto
{
    public class ViewUtils : IViewUtils
    {
        private readonly Container _container;

        public ViewUtils(Container container)
		{
            _container = container;
		}
        public void ShowCurveDataModalView()
        {
            var curveDataView = _container.GetInstance< CurveDataView>();
            curveDataView.ShowDialog();
        }
    }
}
