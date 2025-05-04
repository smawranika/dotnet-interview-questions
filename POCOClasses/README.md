## POCO Classes
POCO stands for **Plain Old CLR Object**.

> A POCO class is a simple C# class that has no dependencies on Entity Framework, no inheritance from special base classes, and no annotations or attributes required for it to function as part of your EF model.

It’s just a regular class with public properties — nothing more.
It is a plain C# class without EF ties.

## Why Use POCOs in Entity Framework?

POCOs give you:
1. **Simplicity**
    - Classes are lightweight and free of EF-specific code.
2. **Separation of Concerns**
    - The domain model stays clean, not tied to the data access layer.
3. **Testability**
    - Easy to unit test without EF context or database.
4. **Flexibility**
    - We can use POCOs with:
        - Code First
        - Database First
        - Model First

## How does EF work with POCOs?
When we use POCOs:
- EF builds the mapping between the class properties and database tables/columns through conventions or Fluent API.
- EF handles change tracking and database operations at runtime, without needing the entities to be tied directly to the EF infrastructure.

#### Example: POCO Class
```csharp
public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public DateTime EnrollmentDate { get; set; }

    // Navigation property
    public ICollection<Course> Courses { get; set; }
}
```
#### Mapping with Fluent API
```csharp
public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("tbl_Students");  // Map to table 'tbl_Students'

            entity.HasKey(e => e.Id);  // Primary key

            entity.Property(e => e.FullName)
                  .HasColumnName("StudentName")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.EnrollmentDate)
                  .HasColumnType("date");
        });
    }
}
```
#### Why use Fluent API?
- For advanced configurations beyond EF’s default conventions.
- To keep POCO classes clean without annotations.
