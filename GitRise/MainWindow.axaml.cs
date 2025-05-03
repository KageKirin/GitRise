using Avalonia.Controls;
using Avalonia.ReactiveUI;

namespace GitRise;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}
