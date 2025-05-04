class Program{
    public static void Main(string[] args){
        #region dynamic
        dynamic dyn= "Hello World";

        Console.WriteLine(dyn.Length); // Works: string has length
        Console.WriteLine(dyn.NonExistentMethod()); // No such method on string! It throws an exception.
        #endregion

        #region object
        object obj = "Hello World";
        Console.WriteLine(obj.NonExistentMethod());  // Compile-time error
        #endregion

    }

}
