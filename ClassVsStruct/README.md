## Class
### Definition
| Aspect | class (Reference Type) | struct (Value Type)
|--------| -----------------------|--------------------
| Definition | Blueprint for creating reference-type objects| Blueprint for creating value-type objects
| Where stored | Allocated on the heap; accessed via reference | Allocated on the stack; copied on assignment

### Memory & Performance
| Feature | class (Reference Type) | struct (Value Type)|
|--------| -----------------------|-------------------- |
| Memory Allocation | Stored on heap | Stored on stack  |
| Garbage Collection | Garbage-collected when no references exist | No grabage collection; lifetime tied to scope

### Inheritance & Polymorphism
| Feature | class (Reference Type) | struct (Value Type)|
|--------| -----------------------|-------------------- |
| Inheritance | Supports inheritance,virtual,override,abstract| Cannot inherit or be inherited |
| Implements Interface | Yes | Yes |
| Finalizer/Desctructor | Can define | Cannot define |

### Constructors & Default Values
| Feature | class (Reference Type) | struct (Value Type)|
|--------| -----------------------|-------------------- |
| Parameterless constructor | Can define one | Cannot define custom; always has implicit |
| Default value | null | All fields are zero-initialized or take the default values of the datatype |
| Can be null? | Yes | No, unless using  Nullable<T> |

### Behavior on Assignment/Passing
| Feature | class (Reference Type) | struct (Value Type)|
|--------| -----------------------|-------------------- |
| Assignment | Copies reference --> two refs to same object | Copies value --> two independent copies |
| Passing to method (default) | Passes reference | Passes value (copy)|
| Modify inside method? | Affects original | Only affects copy (unless passed by ref)|

### Boxing
When you store a struct in a variable of type object or an interface it implements, boxing happens.

- #### Example:
    ```csharp
    Point p = new Point();
    object obj = p;  // p gets boxed (copied to heap)
    ```
- Classes don’t require boxing since they’re already reference types.

## Immutability
Structs are often used for immutable types like:
- `DateTime`
- `TimeSpan`
- `Guid`

## When to Use Which?
| Use Case | Recommendation |
|--------| -----------------------|
| Complex entities, large objects | Use `class` |
| Small, simple data (coordinates, colors, pairs) | Use `struct`|
| Need for inheritance or polymorphism | Only `class` supports this |
| Need nullability | `class` (or use `Nullable<T> for structs)|
| Performance-critical, short-lived values | `struct` (avoid heap allocations)


## Mock Interview Questions
1. Can a struct inherit from a class?

    Structs cannot inherit from another struct or class.They can only implement interfaces.

2. If you pass a struct to a method, does the method change the original?

    No, unless you pass by ref.By default, structs are passed by value (copy). To modify the original, you must pass it as ref.

    Example:

    ```csharp
    void UpdatePoint(Point p) { p.X = 100; }  // copy
    void UpdatePointRef(ref Point p) { p.X = 100; }  // modifies original
    ```
