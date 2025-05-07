## What is Equals()?
- `Equals` is a method used to check if two objects are equal.
- Defined in the base `Object` class.
- Default implementation checks reference equality (i.e., are they the same object in memory).
- We can override in our own class or struct to define value-based equality.

## What is GetHashCode()?
- It returns an int hashcode for an object.
- Used in hash-based collections like Dictionary, HashSet,Hashtable to group objects into buckets.
- If two objects are equal (Equals() returns true), they must have the same hash code.
- If two objects have the same hash code, they may or may not be equal (collisions allowed).

## Example: Bad vs. Correct override
:x: Only override Equals (breaks collections like Dictionary):
```csharp
public override bool Equals(object obj)
{
    return Name == ((Person)obj).Name;
}
// No GetHashCode override
```
✅ Correct override both:
```csharp
public override bool Equals(object obj)
{
    if (obj is not Person other) return false;
    return Name == other.Name && Age == other.Age;
}

public override int GetHashCode()
{
    return HashCode.Combine(Name, Age);
}
```


## Mock Interview Questions
1. Why should you override both Equals() and GetHashCode() together?
    
    Because hash-based collections rely on both methods working correctly.
    If you override Equals() but not GetHashCode(), collections like Dictionary may behave incorrectly (e.g., fail to find items, create duplicates).

2. What happens if two objects have the same hash code but are not equal?

    This is called a hash collision.
    Collections like Dictionary handle collisions internally (usually with linked lists or probing), so correctness is maintained, but performance may degrade.

3. What happens if you use mutable fields in GetHashCode()?

    If you use mutable fields and the value changes after insertion in a hash-based collection, it can break lookup, removal, and contain checks, because the object’s bucket may no longer match.