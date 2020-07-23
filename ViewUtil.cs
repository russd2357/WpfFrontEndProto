using System;
using WpfFrontEndProto.Views;

public static class ViewUtils
{
    public static void ShowCurveDataModalView()
    {
        CurveDataView curveDataView = new CurveDataView();
        curveDataView.ShowDialog();
    }
}