# NetShellCommand

```csharp
public class NetShellCommand:INetShellCommand
```

Command for NetShell.

<br>

## Constructors

```csharp
public NetShellCommand(string cmd)
```
Initialize new instance.<br>
``cmd``: Set to ``Command`` property.

# 

```csharp
public NetShellCommand(string cmd,string desc)
```
Initialize new instance.<br>
``cmd``: Set to ``Command`` property.<br>
``desc``: Set to ``Description`` property.

# 

```csharp
public NetShellCommand(string cmd,string desc,Action act)
```
Initialize new instance.<br>
``cmd``: Set to ``Command`` property.<br>
``desc``: Set to ``Description`` property.<br>
``act``: Set to ``Action`` property.

<br>

## Properties

```csharp
public virtual string Command { get; set; }
```
Command.

#

```csharp
public virtual string Description { get; set; }
```
Description of command.

# 

```csharp
public virtual Action<INetShellCommand,sring> Action { get; set; }
```
Action of command.
