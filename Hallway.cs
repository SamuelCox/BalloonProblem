using System.Collections.Generic;
 
namespace BalloonProblem
{
    public class Hallway
    {
        private List<Balloon> _balloons;
        private DuplicatesDictionary<string, string> _lookup;

        public Hallway(List<Balloon> balloons)
        {
            _balloons = balloons;
            _lookup = new DuplicatesDictionary<string, string>();
            foreach (var balloon in _balloons)
            {
                _lookup.Add(balloon.Name, balloon.Name);
            }
        }
        
        public void DequeueBalloonLinear(Student student)
        {
            _balloons.Remove(new Balloon(student.Name));
        }

        /// <summary>
        /// This method really isn't in the spirit of the problem.
        /// It will be the best in code terms, but of course in the real world the hallway of balloons
        /// can't suddenly organise itself into a hashtable/lookup/dictionary. (Too many terms for this in c# world)
        /// Also we use a lookup rather than say a hashset as it is possible for students to have duplicate names.
        /// </summary>
        /// <param name="student"></param>
        public void FakeHashTableSolution(Student student)
        {
            _lookup.Remove(student.Name);
        }

        public int Count()
        {
            return _balloons.Count;
        }
    }
}
