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

## Events

<b>CommandProcess</b>: This happens before command processing.<br>
<b>CommandProcessed</b>: This happens after command processed.

<br>

## Members

```csharp
public void AddCmd(string cmd,string desc,Action act)
```
Add new command to commands.<br>
``cmd``: Command.<br>
``desc``: Description of command.<br>
``act``: Action of command.

# 

```csharp
public void Loop()
```
Start command loop.

<br>

## Properties

```csharp
public virtual List<INetShellCommand> Commands { get; }
```
Commands of shell.

# 

```csharp
public virtual string Prompt { get; set; }
```
Prompt input.
