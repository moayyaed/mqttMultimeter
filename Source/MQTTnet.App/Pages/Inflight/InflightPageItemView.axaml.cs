using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MQTTnet.App.Pages.Inflight;

public sealed class InflightPageItemView : UserControl
{
    public InflightPageItemView()
    {
        InitializeComponent();
    }

    void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}