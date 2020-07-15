# ParameterEngine

```csharp
public static class ParameterEngine
```

Parameter engine of NetShell.

<br>

## Members

```csharp
public static string GetNamespace(this string cmd)
```
Returns namespace of command.
``cmd``: Command.

# 

```csharp
public static string RemoveNamespace(this string cmd)
```
Returns removed namespace command.<br>
``cmd``: Command.

# 

```csharp
public static List<string> GetParameters(this string cmd,string delimiter)
```
Returns parameter(s) of command.<br>
``cmd``: Command.<br>
``delimiter``: Parameter delimiter.

# 

```csharp
public static List<string> GetParameters(this string cmd,Regex pattern)
```
Returns parameter(s) of command.<br>
``cmd``: Command.<br>
``pattern``: Pattern of parameters.

# 

```csharp
public static string RemoveParameters(this string cmd,string delimiter)
```
Returns removed parameters command.<br>
``cmd``: Command.<br>
``delimiter``: Parameter delimiter.

# 

```csharp
public static string RemoveParameters(this string cmd,Regex pattern)
```
Returns removed parameters command.<br>
``cmd``: Command.<br>
``pattern``: Pattern of parameters.

## Example

```csharp
using NetSh.Tools;

namespace Example {
    public static class Program {
        public static void Main() {
            string mystr = "TestNamespace -param1 -param2 -param3";
            string args = mystr.RemoveNamespace(); // -param1 -param2 -param3
            args.ForEach(x => Console.WriteLine(x));
        }
    }
}

/*
OUTPUT

-param1
-param2
-param3

*/
```
