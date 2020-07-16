# GenericExtensions

```csharp
public static class GenericExtensions
```

Adds plugin functions for all types.

<br>

## Members

```csharp
public static void Print(this object obj)
```
If the value characterizes the ``IEnumerable`` interface, it prints all items side by side (except for the ``string``). If not, it prints the value directly.
``obj``: Object to print.

# 

```csharp
public static void Print(this object obj,ConsoleColor color)
```
If the value characterizes the ``IEnumerable`` interface, it prints all items side by side (except for the ``string``). If not, it prints the value directly.
``obj``: Object to print.
```color``: Forground color.

# 

```csharp
public static void Println(this object obj)
```
If the value characterizes the ``IEnumerable`` interface, it prints all items line by line (except for the ``string``). If not, it prints the value directly.
``obj``: Object to print.

# 

```csharp
public static void Println(this object obj,ConsoleColor color)
```
If the value characterizes the ``IEnumerable`` interface, it prints all items line by line (except for the ``string``). If not, it prints the value directly.
``obj``: Object to print.
``color``: Foreground color.

## Example

```csharp
using NetSh.Extensions;

namespace Example {
    public static class Program {
        public static void Main() {
            var mystr = "My string";
            mystr.Print();
            "\n-----\n".Print();

            var mycoll = new string[] {
                "My",
                "string",
                "collection"
            };
            mycoll.Println();
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
