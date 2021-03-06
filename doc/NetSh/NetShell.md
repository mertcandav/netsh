# NetShell

```csharp
public class NetShell
```

NetShell, shell tool.

> By default, ``clear``,``exit`` and ``help`` commands are defined.

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
<b>CommandProcessed</b>: This happens after command processed.<br>
<b>BeforePrompt</b>: This happens before Prompt print.<br>
<b>AfterPrompt</b>: This happens after Prompt print.

<br>

## Members

```csharp
public virtual void AddCmd(string cmd,string desc,Action<INetShellCommand,string> act)
```
Add new command to commands.<br>
``cmd``: Command.<br>
``desc``: Description of command.<br>
``act``: Action of command.

# 

```csharp
public virtual void Loop()
```
Start command loop.

# 

```csharp
public virtual void PostCmd()
```
Run a command shell entry.

# 

```csharp
public virtual void Help(int spacecount)
```
Show help.
``spacecount``: Whitespace count of between commands and descriptions.

# 

```csharp
public virtual void Exit()
```
Exit from shell on next command.

# 

```csharp
public virtual string GetInput()
```
Returns user input by shell settings.

# 

```csharp
public virtual IEnumerable<INetShellCommand> GetCommands(strign cmd)
```
Returns matched commands by shell settings.
``cmd``: Command sample.

# 

```csharp
public virtual bool ProcessCommand(string cmd)
```
Process the command and returns true if success, returns false if not.

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

# 

```csharp
public virtual ConsoleColor PromptColor { get; set; }
```
Color of Prompt.

# 

```csharp
public virtual bool IgnoreWhiteSpace { get; set; }
```
Ignore whitespace at start and end on commands.

# 

```csharp
public virtual bool IgnoreCase { get; set; }
```
Ignore case on commands.

# 

````csharp
public virtual NetShellMode Mode { get; set; }
```
Mode of shell.
