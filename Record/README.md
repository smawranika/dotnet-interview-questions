## Record
A record in C# is a reference type introduced in C# 9.0 (2020) designed for:
- Immutable data models (by default)
- Value-based equality (compared by content, not by reference)
- Concise syntax for creating simple data carriers like DTOs (Data Transfer Objects)

#### Example:
```csharp
public record Person(string Name, int Age);
```
This is called a positional record — it automatically creates:
- Properties: `Name`, `Age`
- A constructor
- `Equals()` and `GetHashCode()` based on the values, not the reference
- `ToString()` override with readable output.

## Key Differences: Record vs Class
| Feature | class | record |
|--------| -----------------------|--------------------|
| Type | Reference type | Reference type (or value type with record struct)|
| Equality | Reference equality (compares by memory address) | Value equality (compares by property values)|
| Immutability(by default)| Mutable (unless coded otherwise) | Immutable (init-only properties by default)|
| Intended for | Behavior + data | Pure data models (DTOs, state containers)|

## How Record Equality Works
```csharp
var p1 = new Person("Alice", 30);
var p2 = new Person("Alice", 30);

Console.WriteLine(p1 == p2);  // True — compares values!
```
Compare this to a class:
```csharp
public class PersonClass
{
    public string Name { get; init; }
    public int Age { get; init; }
}
```
Here, two instances with the same property values would not be == or .Equals() unless you manually override them.

## Record Types in C#
| Type | Example|
|------| -------|
| Reference record | `public record Person(string Name, int Age);`|
| Mutable record | `public record Person { string Name; int Age; }` (properties are mutable unless using init)|
| Value-type record (C# 10) | `public record struct Point(int X, int Y);`|

## Immutability (Init-Only Properties)
Records use init-only properties by default:
```csharp
var p = new Person("Alice", 30);
p.Age = 31;  // ❌ Compile-time error (immutable)
```
But we can make **mutable** records if needed:
```csharp
public record MutablePerson
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

##  With-Expressions for Copying
Records support non-destructive mutation (copying with modifications):
```csharp
var p1 = new Person("Alice", 30);
var p2 = p1 with { Age = 31 };

Console.WriteLine(p2);  // Person { Name = Alice, Age = 31 }
```

`with` creates a new copy with the specified changes — original stays untouched.

## Deconstruction
We can deconstruct a record easily:
```csharp
var person = new Person("Alice", 30);
var (name, age) = person;

Console.WriteLine(name);  // Alice
Console.WriteLine(age);   // 30
```

## Inheritance
Records support inheritance:
```csharp
public record Person(string Name);
public record Employee(string Name, string Department) : Person(Name);
```

## When to use Records
For data-carrying types like:
- API responses
- Immutable configurations
- State models in functional/reactive programming
- Lightweight DTOs (Data Transfer Objects)

## record vs record struct
- `record` --> reference type (on heap, garbage collected)
- `record struct` --> value type (stack, no GC), bu still has value-based equality and `with` expression.

