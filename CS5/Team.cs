using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS5
{
    class Team:IComparable
    {

        public string Name { get; set; }
        public int WonMatches { get; set; }
        public int LostMatches { get; set; }
        public int DrawMatches { get; set; }
        public int AllMatches { get; set; }
        public int Goals { get; set; }
        public int Misses { get; set; }
        public int Points { get; set; }
        public Team(string name)
        {
            Name = name;
            AllMatches = 0;
            WonMatches = 0;
            LostMatches = 0;
            DrawMatches = 0;
            Goals = 0;
            Misses = 0;
            Points = 0;
        }
        public override string ToString()
        {
            return $"|{Name}  |  {Points}     |  {AllMatches}  |  {WonMatches}   |  {DrawMatches}    |  {LostMatches}    |  {Goals}    |  {Misses}     |";
        }

        public int CompareTo(object obj)
        {
            
            if(obj is Team)
            {
                return Points.CompareTo((obj as Team).Points);
            }
            
            throw new NotImplementedException();
        }
    }
}
