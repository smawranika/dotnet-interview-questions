## `Lazy<T>`
`Lazy<T>` is a generic class in C# that provides lazy initialization — meaning the value of type T is not created until it’s actually needed.

It’s part of the System namespace and helps improve performance or avoid unnecessary work by delaying expensive operations until you access the .Value property.

### Example:
```csharp
Lazy<HeavyObject> lazyObj = new Lazy<HeavyObject>();

// Nothing is created yet.

var obj = lazyObj.Value;  
// Now HeavyObject is constructed on first access.
```

## How it Works
- First access to .Value triggers creation.
- Subsequent accesses return the same cached value.
- It internally manages whether the value has been created or not.

## Thread Safety
By default, Lazy<T> is thread-safe.
It uses LazyThreadSafetyMode.ExecutionAndPublication:
- Only one thread creates the value.
- Other threads wait and get the same result.

We can customize it:
```csharp
Lazy<HeavyObject> lazyObj = new Lazy<HeavyObject>(
    () => new HeavyObject(),
    LazyThreadSafetyMode.PublicationOnly);
```

## Key Members
| Type | Example|
|------| -------|
| `.Value` | Gets the initialized value (triggers creation if not yet done)|
| `.IsValueCreated` | Returns true if the value has been initialized.|
| `.ToString()` | Calls .Value.ToString() if value is created;otherwise returns type name|

## Custom Factory Function
We can pass a custom initilization delegate:
```csharp
Lazy<HeavyObject> lazyObj = new Lazy<HeavyObject>(() =>
{
    Console.WriteLine("Factory called.");
    return new HeavyObject();
});
```

## When should we use it?
- You have expensive initialization (e.g., large objects, I/O, DB queries).
- You might never need the object.
- You want thread-safe lazy loading without manual locking.

## Lazy Singleton Pattern
```csharp
public class Singleton
{
    private static readonly Lazy<Singleton> _instance = new(() => new Singleton());

    public static Singleton Instance => _instance.Value;

    private Singleton() { }
}
```
 This ensures thread-safe singleton creation only when needed and eliminates the need for lock.

