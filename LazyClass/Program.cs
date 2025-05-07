// Example with Heavy Object
public class HeavyObject{
    public HeavyObject(){
        Console.WriteLine("Heavy Object Created!");
    }
}

class Program{
    public static void Main(string[] args){
        Lazy<HeavyObject> lazyObj= new();
        
        Console.WriteLine("Before accessing value.");

        // HeavyObject not created yet.
        var obj = lazyObj.Value;  // <-- Created here

        Console.WriteLine("After accessing Value.");

        // Without Lazy class
        HeavyObject heavyObject= new();
        Console.WriteLine("Before accessing value.");
        Console.WriteLine("After accessing Value.");

        }
}