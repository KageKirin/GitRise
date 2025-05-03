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
    public MainWindowViewModel()
    {
        RefreshCommits = ReactiveCommand.CreateFromTask(async _ =>
        {
            Commits.Clear();

            // dummy data, in fact valid commits from GitConfigurationProvider
            Commits.Add(new("ad54ae7", "repo: initialize"));
            Commits.Add(new("9ca189e", "feat: add initial documentation (feat/documentation) [#1]"));
            Commits.Add(new("882a2bc", "feat: add solution and build configuration files (feat/build-files) [#2]"));
            Commits.Add(new("f4f867d", "feat: add project files (feat/projects) [#3]"));
            Commits.Add(new("7833026", "feat: implement initial functionality and test program (feat/initial-implementation) [#4]"));
            Commits.Add(new("4dd3e2a", "feat(ci): implement GitHub Action workflows (feat/gha-ci-workflows) [#5]"));
            Commits.Add(new("ffdada2", "refactor: allow optional git configuration (refactor/optional-configuration) [#6]"));
            Commits.Add(new("b43b6b7", "feat: implement GitConfigurationProvider constructor taking LibGit2Sharp.Configuration (feat/provider-ctor-with-repo-config) [#7]"));
            Commits.Add(new("bb7d4a3", "feat: extend GitConfigurationProvider API with factory method taking repo/global/xdg/system configuration paths (feat/config-path) [#8]"));
            Commits.Add(new("fa4b7c0", "feat: extend GitConfigurationProvider API with factory method taking a Repository instance (feat/config-from-repo) [#9]"));
            Commits.Add(new("3a67b56", "feat: implement initial support for reloading the configuration on change (feat/reload-config) [#10]") );  Commits.Add(new("e824400", "feat: implemented GitConfigurationWatcher as CLI tool for watching the configuration refresh (feature/watcher-tool) [#11]"));
            Commits.Add(new("bc4a713", "feat: implement Avalonia app displaying command alias from the git configuration (feature/viewer-tool-avalonia) [#12]"));
            Commits.Add(new("0f91fda", "feat: implement unit tests and enable them in CI (feat/unit-tests) [#13]"));
            Commits.Add(new("6fc98b1", "refactor: unit tests modify the global configuration (refactor/unit-tests) [#14]"));
            Commits.Add(new("079b2a7", "build: switch unit tests to Xunit.v3 (build/xunit-v3) [#15]"));
        });

        this.WhenActivated(disposable =>
        {
            RefreshCommits.Execute().Subscribe().DisposeWith(disposable);
        });

        RefreshCommits.Execute();
    }

    public ReactiveCommand<Unit, Unit> RefreshCommits { get; }

    public ObservableCollection<Commit> Commits { get; } = new();

    #region IActivatableViewModel
    public ViewModelActivator Activator { get; } = new();
    #endregion
}
