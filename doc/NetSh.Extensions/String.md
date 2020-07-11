# String

```csharp
public static class String
```

Adds plugin functions for strings.

<br>

## Members

```csharp
public static void Write(this string str)
```
Print console.

# 

```csharp
public static void WriteLine(this string str)
```
Print console and new line.

#

```csharp
public static void WriteChars(this string str)
```
Prints all charcters side by side.

#

```csharp
public static void WriteLineChars(this string str)
```
Prints all charcters line by line.

## Example

```csharp
using NetSh.Extensions;

namespace Example {
    public static class Program {
        public static void Main() {
            var mystr = "My string";
            mystr.Write();

            "\n---".WriteLine();
            "ABCDEFG".WriteChars();
        }
    }
}

/*
OUTPUT

My string
---
A B C D E F G
*/
```
