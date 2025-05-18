## What is `Span<T>`
`Span<T>` is a memory-efficient, safe and high-performance structure that represents a contiguous region of arbitrary memory (like an array, stack-allocated memory, or slice of an existing buffer) without copying the data. It allows to:
- Work with slices of arrays,strings or memory buffers.
- Avoid allocations and improve performance.
- Operate safely without creating new arrays.

### Key Features
| Feature | Explanation |
|---------|-------------|
| Zero Allocation | You can work on existing memory without creating new arrays.|
| Fast | Used for performance-critical code, like parsing,buffers etc.|
| Stack-only | As a `ref struct` it cannot be stored on the heap, avoiding memory leaks or misuse.|

### Real-World Use Case: String Slicing
```csharp
ReadOnlySpan<char> span = "Hello World".AsSpan();
ReadOnlySpan<char> world = span.Slice(6, 5);
Console.WriteLine(world.ToString());  // Output: World
```

### `Span<T>` vs `ReadOnlySpan<T>`
- `Span<T>` -> Read/Write access
- `ReadonlySpan<T>` -> Read-only access (great for strings & immutability)

### When should you use `Span<T>`?
- You need to manipulate a portion of a buffer.
- You want to avoid allocations in high-performance code.
- You're parsing data (e.g., CSVs, JSON), building in-memory protocols, or doing low-level byte processing.

