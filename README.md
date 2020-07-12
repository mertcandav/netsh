# NetSh - A .NET CLI and Shell framework
[![license](https://img.shields.io/badge/License-MIT-BLUE.svg)](https://opensource.org/licenses/MIT)
![CI](https://github.com/mertcandav/netsh/workflows/CI/badge.svg)
[![Build Status](https://dev.azure.com/mertcandav/netsh/_apis/build/status/mertcandav.netsh?branchName=master)](https://dev.azure.com/mertcandav/netsh/_build/latest?definitionId=8&branchName=master)
[![Build Status](https://travis-ci.org/mertcandav/netsh.svg?branch=master)](https://travis-ci.org/mertcandav/netsh)

<b>CLI/Shell framework for .NET.</b>

<br>

## Compatibility
<table>
  <tr>
    <td>.NET Standard</td>
    <td>.NET Core</td>
    <td>.NET Framework</td>
  </tr>
  <tr>
    <td>1.3 or higher</td>
    <td>1.1 or higher</td>
    <td>4 or higher</td>
  </tr>
</table>

<br>

## Quick Start

Use this namespace(s).
```csharp
using NetSh;
```

Define your shell tool.
```csharp
NetShell shell = new NetShell();
shell.Prompt = "MyShell$ ";
```

Define your test command and start shell loop.
```csharp
shell.AddCmd("Foo", "My test command.", () => {
    Console.WriteLine("Bar");
});
shell.Loop();
```

Try ``Foo`` command.
```
MyShell$ Foo
Bar
MyShell$ 
```

Try ``Help`` command.
```csharp
MyShell$ Help
help                    Show help.
exit                    Exit from shell.
Foo                     My test command.
MyShell$ 
```
Have fun!
