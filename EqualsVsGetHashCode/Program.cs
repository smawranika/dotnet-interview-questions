public class Person{
    public string Name { get; set; }
    public int Age { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Person other) return false;
        return Name==other.Name && Age==other.Age;
    }
}

class Program{
    public static void Main(string[] args){
        Person person = new()
        {
            Name = "ABC",
            Age = 10
        };

        Person person1 = new()
        {
            Name = "DEF",
            Age = 20
        };

        Person person2 = new()
        {
            Name = "ABC",
            Age = 10
        };

        Console.WriteLine(person.Equals(person1));
        Console.WriteLine(person.Equals(person2));
    }
}