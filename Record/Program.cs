// CLASS VERSION
    public class PersonClass
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is not PersonClass other) return false;
            return Name == other.Name && Age == other.Age;
        }

        public override int GetHashCode() => HashCode.Combine(Name, Age);

        public override string ToString() => $"PersonClass {{ Name = {Name}, Age = {Age} }}";
    }

// RECORD VERSION
    public record PersonRecord(string Name, int Age);

    class Program
    {
        static void Main()
        {
            // CLASS TEST
            var classPerson1 = new PersonClass { Name = "Alice", Age = 30 };
            var classPerson2 = new PersonClass { Name = "Alice", Age = 30 };

            Console.WriteLine($"Class Equals: {classPerson1.Equals(classPerson2)}");  // True
            Console.WriteLine($"Class == operator: {classPerson1 == classPerson2}");   // False (reference equality)
            Console.WriteLine($"Class ToString: {classPerson1}");

            // RECORD TEST
            var recordPerson1 = new PersonRecord("Alice", 30);
            var recordPerson2 = new PersonRecord("Alice", 30);

            Console.WriteLine($"Record Equals: {recordPerson1.Equals(recordPerson2)}");  // True
            Console.WriteLine($"Record == operator: {recordPerson1 == recordPerson2}");   // True (value equality)
            Console.WriteLine($"Record ToString: {recordPerson1}");

            // RECORD WITH EXPRESSION
            var updatedRecord = recordPerson1 with { Age = 31 };
            Console.WriteLine($"Updated Record: {updatedRecord}");

            // DECONSTRUCTION
            var (name, age) = recordPerson1;
            Console.WriteLine($"Deconstructed: Name={name}, Age={age}");
        }
    }