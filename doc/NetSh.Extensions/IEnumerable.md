# GenericExtensions

```csharp
public static class IEnumerable
```

Adds plugin functions for IEnumerable interface.

<br>

## Members

```csharp
public static void Write(this System.Collections.IEnumerable collection)
```
Prints all items side by side.

# 

```csharp
public static void WriteLine(this System.Collections.IEnumerable collection)
```
Prints all items line by line.

#

```csharp
public static void GetValue(this System.Collections.IEnumerable collection,char sep)
```

Returns console value of items.

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
            Console.Write(IEnumerable.GetValue(mycoll,' ') // or mycoll.GetValue(' '));
        }
    }
}

/*
OUTPUT

M y  s t r i ng
My
string
collection
My string collection
*/
```
