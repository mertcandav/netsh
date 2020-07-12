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

<br>

## Properties

```csharp
public virtual INetShellCommand Cmd { get; protected set; }
```
Command of event.
