# Git Rise (prototype)

![Icon.png](Metro map style icon)

GitRise is currently a prototype for a visual Git client,
targeting macOS, Linux and Windows.

The main idea so far is to imitate the very excellent [gitup](https://gitup.co),
but to make it multiplatform using C# and [AvaloniaUI](https://avaloniaui.net).

Planned features:

- metro-map style commit tree visualization,
- diff view,
- hunk-by-hunk and line-by-line staging,
- stash view,
- rebasing assistant,
- commit reordering (rebase, but simpler)

## ⚡ Status

Prototype, just getting started.

## 🔧 Building and Running

We are currently using .NET 9.0.

### 🔨 Build the Project

```bash
dotnet build
```

### ▶ Running

```bash
dotnet run
```

### ⚙️ Settings

TBD once we actually configuration to set.

`gitrise.toml`

```toml
[rise]

[Logging.LogLevel]
Default = Trace


```

`git config`

```toml
[rise]

```

## 🤝 Collaborate with My Project

Please refer to [COLLABORATION.md](COLLABORATION.md).
