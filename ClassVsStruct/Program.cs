struct Point{
    public int X;
    public int Y;
}

class Program{
    static void Main(string[] args){
        Point point = new Point();
        point.X = 10;
        point.Y = 20;

        Point point_new = point;
        point_new.X = 100;
        point_new.Y = 200;

        Console.WriteLine(point.X);
        Console.WriteLine(point_new.X);

    }
}
