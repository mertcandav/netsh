# GenericExtensions

```csharp
public static class IEnumerable
```

Adds plugin functions for IEnumerable interface.

<br>

## Members

```csharp
public static void Write(T obj)
```
Prints all items side by side.

# 

```csharp
public static void WriteLine(T obj)
```
Prints all items line by line.

## Example

```csharp
using NetSh.Extensions;

namespace Example {
    public static class Program {
        public static void Main() {
            var mystr = "My string";
            IEnumerable.Write(mystr); // or mystr WriteChars();

            var mycoll = new string[] {
                "My",
                "string",
                "collection"
            };
            IEnumerable.WriteLine(mycoll); // or mycoll.WriteLine();
        }
    }
}

/*
OUTPUT

M y  s t r i ng
My
string
collection

*/
```
