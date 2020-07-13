# NetShellEventArgs

```csharp
public class NetShellEventArgs:EventArgs
```
Event arguments for NetShell.

<br>

## Constructors

```csharp
public NetShellEventArgs(INetShellCommand cmd)
```
Initialize new instance.<br>
``cmd``: Set to ``Cmd`` property.

# 

```csharp
public NetShellEventArgs(INetShellCommand cmd,string intput)
```
Initialize new instance.<br>
``cmd``: Set to ``Cmd`` property.<br>
``input``: Inputted command.

<br>

## Properties

```csharp
public virtual INetShellCommand Cmd { get; protected set; }
```
Command of event.

# 

```csharp
public virtual string Input { get; set; }
```
Inputted command.
