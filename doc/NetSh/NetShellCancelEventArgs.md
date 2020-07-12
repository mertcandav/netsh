# NetShellCancelEventArgs

```csharp
public class NetShellCancelEventArgs:EventArgs
```
Cancel event arguments for NetShell.

<br>

## Constructors

```csharp
public NetShellCancelEventArgs(INetShellCommand cmd)
```
Initialize new instance.<br>
``cmd``: Set to ``Cmd`` property.

<br>

## Properties

```csharp
public virtual INetShellCommand Cmd { get; set; }
```
Command of event.

# 

```csharp
public virtual bool Cancel { get; set; }
```
Cancel state of process.
