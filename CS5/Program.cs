using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS5
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team1 = new Team("  Real Madrid    ");
            Team team2 = new Team("  Barselona      ");
            Team team3 = new Team("  Sevilia        ");
            Team team4 = new Team("  Atletico Madrid");
            Team team5 = new Team("  Valencia       ");
            Random random = new Random();
            List<Team> teams = new List<Team>() { team1,team2,team3,team4,team5};
            List<Team> teams_list_for_print = new List<Team>() { team1,team2,team3,team4,team5};
            
            int top = 1;
            Console.SetCursorPosition(80, top);
            Console.WriteLine("The matches begin!");
            Thread.Sleep(2000);
            top++;
            
            int k = 1;
            int n1=0,n2=0;
            int n1_r=0,n2_r=0;

            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    
                    teams_list_for_print.Sort();
                    teams_list_for_print.Reverse();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("|  Team             | Points | All | Wins | Draws | Loses | Goals | Misses |");
                    Console.WriteLine("|--------------------------------------------------------------------------|");
                    foreach (var item in teams_list_for_print)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("|--------------------------------------------------------------------------|");

                    Thread.Sleep(1000);



                    Console.SetCursorPosition(80, top);
                    Console.WriteLine($"Match {k}: {teams[i].Name} vs {teams[j].Name} ");
                    top++;
                    
                    Thread.Sleep(2000);
                    Console.SetCursorPosition(80, top);
                    n1_r = random.Next(5);
                    Thread.Sleep(100);
                    n2_r = random.Next(5);
                    Console.WriteLine($" {n1} : {n2}");
                    Thread.Sleep(1000);

                    while (n1!=n1_r||n2!=n2_r)
                    {
                        

                        if (n1 != n1_r) n1++;
                        if (n2 != n2_r) n2++;

                        Console.SetCursorPosition(80, top);
                        Console.WriteLine($" {n1} : {n2}");
                        Thread.Sleep(1000);
                    }
                    top++;
                    Console.SetCursorPosition(80, top);
                    if (n1_r > n2_r)
                    {
                        Console.WriteLine($"{teams[i].Name} won!");
                        teams[i].Points += 3;
                        
                        teams[i].WonMatches++;

                        teams[j].LostMatches++;
                    }
                    else if (n1_r < n2_r)
                    {
                        Console.WriteLine($"{teams[j].Name} won!");
                        teams[j].Points += 3;
                     
                        teams[j].WonMatches++;


                        teams[i].LostMatches++;
                    }
                    else
                    {
                        Console.WriteLine("Draw!");
                        teams[i].DrawMatches++;
                        teams[j].DrawMatches++;
                        teams[i].Points++;
                        teams[j].Points++;

                    }
                    teams[i].AllMatches++;
                    teams[j].AllMatches++;
                    teams[i].Goals += n1_r;
                    teams[i].Misses += n2_r;
                    teams[j].Goals += n2_r;
                    teams[j].Misses += n1_r;
                    top++;
                    n1 = 0;
                    n2 = 0;
                    k++;
                    Thread.Sleep(2000);
                }
            }
            teams_list_for_print.Sort(delegate (Team x, Team y) {
                int ans = x.Points.CompareTo(y.Points);

                if (x.Points == y.Points)
                {
                    ans = x.Goals.CompareTo(y.Goals);
                }

                return ans;
            });
            teams_list_for_print.Reverse();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("|  Team             | Points | All | Wins | Draws | Loses | Goals | Misses |");
            Console.WriteLine("|--------------------------------------------------------------------------|");
            foreach (var item in teams_list_for_print)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("|--------------------------------------------------------------------------|");

            Console.WriteLine(teams_list_for_print[0].Name+ " has won the tournament!");
        }
    }
}
