# INetShellCommand

```csharp
public interface INetShellCommand
```

Interface for NetShell commands.

<br>

## Properties

```csharp
string Command { get; set; }
```
Command.

#

```csharp
string Description { get; set; }
```
Description of command.

# 

```csharp
Action Action { get; set; }
```
Action of command.

