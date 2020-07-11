# NetShellCommand

```csharp
public class NetShell
```

NetShell, shell tool.

<br>

## Constructors

```csharp
public NetShell()
```
Initialize new instance.

# 

```csharp
public NetShell(params INetShellCommand[] commands)
```
Initialize new instance.<br>
``commands``: Set to ``Commands`` property.

# 

```csharp
public NetShell(IEnumerable<INetShellCommand> commands)
```
Initialize new instance.<br>
``commands``: Set to ``Commands`` property.

<br>

## Properties

```csharp
public virtual INetShellCommand[] Commands { get; set; }
```
Commands of shell.
