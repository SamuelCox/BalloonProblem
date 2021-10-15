using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BalloonProblem
{
    public static class Seeder
    {
        private static string[] _nameCsvFiles = new[] { "randomnames_1_5.csv", "randomnames_2_5.csv", "randomnames_3_5.csv", "randomnames_4_5.csv", "randomnames_5_5.csv" };

        public static List<Balloon> GenerateBalloons(List<Student> students)
        {
            var rng = new Random();
            var balloons = students.Select(x => new Balloon(x.Name)).ToArray();
            int n = balloons.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                var temp = balloons[n];
                balloons[n] = balloons[k];
                balloons[k] = temp;
            }
            return balloons.ToList();
        }

        public static List<Student> GenerateStudents()
        {
            var students = new List<Student>();
            foreach (var csvFile in _nameCsvFiles)
            {
                using (var reader = new StreamReader($"resources/{csvFile}"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StudentCsvRecord>();
                    students.AddRange(records.Select(x => new Student($"{x.FirstName} {x.LastName}")));
                }
            }
            return students;
            
        }
    }
}
