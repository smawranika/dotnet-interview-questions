## `object` Type

- It is the base type of all types in .NET.
- Every type (value type or reference type) can be assigned to an object variable.
- The compiler knows nothing about the specific type stored in object.
So,it must be cast back to the original type before accessing members.
- Example:
    ```csharp
    object obj = "Hello World";
    // Need explicit cast:
    int length = ((string)obj).Length;
    ```
- Performance:
    
    Boxing happens when storing value types in object. This adds overhead.

## `dynamic` Type

- It tells the compiler:

    "Trust me, I know what type this will be at runtime.”

- The compiler skips type checking. It defers all member resolution to runtime.
- Example:
    ```csharp
    dynamic dyn = "Hello World";
    // No cast needed:
    int length = dyn.Length;
    ```
- If you call a non-existent member, it compiles fine but throws a runtime error.

## Key Differences
| Feature | `object`|  `dynamic`
| -------- | -------- |   --------
| Compile-time checking   | Yes  |  No (resolved at runtime)
| Casting needed   | Yes (for specific members)   | No (compiler trusts you)
| Performance | Safer, potentially faster | Slower due to runtime binding
| Error Detection | At compile time | Only at runtime
| Use Cases | General storage of any type | Interop with dynamic languages, JSON

## When to Use What?
- Use `object` when you need type safety but want to hold any type.
- Use `dynamic` when interacting with dynamic data, like:
    - COM objects
    - Reflection-heavy code
    - JSON/XML where the shape isn't known in advance.