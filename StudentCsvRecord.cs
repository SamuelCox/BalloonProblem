using CsvHelper.Configuration.Attributes;

namespace BalloonProblem
{
    public class StudentCsvRecord
    {
        [Name("First Name")]
        public string FirstName { get; set; }

        [Name("Last Name")]
        public string LastName { get; set; }
    }
}
