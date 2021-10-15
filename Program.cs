using System;
using System.Diagnostics;

namespace BalloonProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = Seeder.GenerateStudents();
            var balloons = Seeder.GenerateBalloons(students);
            var hallway = new Hallway(balloons);
            Stopwatch stopWatch = new Stopwatch();


            Console.WriteLine("Linear remove starting");
            stopWatch.Start();
            foreach (var student in students)
            {
                hallway.DequeueBalloonLinear(student);
                //For accurate timing you should comment out next line of code as IO is expensive
                //Console.WriteLine($"{hallway.Count()} balloons remaining, {student.Name} found theirs");
            }
            stopWatch.Stop();
            Console.WriteLine($"Linear remove finished in {stopWatch.ElapsedMilliseconds} ms");
            stopWatch.Reset();

            stopWatch.Start();
            Console.WriteLine("Not real world solution hashmap starting");
            foreach (var student in students)
            {
                hallway.FakeHashTableSolution(student);
            }
            stopWatch.Stop();
            Console.WriteLine($"Hashmap finished in {stopWatch.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
