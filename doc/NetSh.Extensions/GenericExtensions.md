# GenericExtensions

```csharp
public static class GenericExtensions<T>
```

Adds plugin functions for all types.

<br>

## Members

```csharp
public static void Write(T obj)
```
If the value characterizes the ``IEnumerable`` interface, it prints all items side by side (except for the ``string``). If not, it prints the value directly.

# 

```csharp
public static void WriteLine(T obj)
```
If the value characterizes the ``IEnumerable`` interface, it prints all items line by line (except for the ``string``). If not, it prints the value directly.

## Example

```csharp
using NetSh.Extensions;

namespace Example {
    public static class Program {
        public static void Main() {
            var mystr = "My string";
            mystr.Write();
            "\n-----\n".Write();

            var mycoll = new string[] {
                "My",
                "string",
                "collection"
            };
            mycoll.WriteLine();
        }
    }
}

/*
OUTPUT

My string
-----
My
string
collection

*/
```
