using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using GitRise.Models;
using ReactiveUI;

namespace GitRise;

public class MainWindowViewModel : ViewModelBase, IActivatableViewModel
{
    public MainWindowViewModel() {}

    #region IActivatableViewModel
    public ViewModelActivator Activator { get; } = new();
    #endregion
}
