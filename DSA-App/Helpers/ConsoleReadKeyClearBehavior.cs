using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_And_Algorithm.Helpers
{
    public class ConsoleReadKeyClearBehavior
    {
        public static void ReadKeyAndClear()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ExerciseNotComplete()
        {
            Console.WriteLine("This exercise has not been completed yet, but thanks for dropping by!");
            ReadKeyAndClear();
        }
    }
}
