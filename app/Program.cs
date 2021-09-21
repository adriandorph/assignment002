using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new ImmutableStudent(1, "givenname", "surname", new DateTime(2020, 8, 24), new DateTime(2023, 6, 25), new DateTime(2023, 6, 26)));
            
        }
    }
}
