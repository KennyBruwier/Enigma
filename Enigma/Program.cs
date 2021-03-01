using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Program
    {
        /*Hello! This is an Enigma Machine.
         * Currently your machine is set up like this:
         * 
         * [ R1 ][ R2 ][ R3 ]
         * [ 01 ][ 01 ][ 01 ]
         * 
         * ABCDEFGHIJKLMNOPQRSTUVWXYZ
         * ||||||||||||||||||||||||||
         * ABCDEFGHIJKLMNOPQRSTUVWXYZ
         * 
         * [1] Use the machine.
         * [2] Change the rotors.
         * [3] Wire the plugbox.
         * [4] Exit the application.
         * 
         */
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello! This is an Enigma Machine.\nCurrently your machine is set up like this:\n\n");

            Rotor[] aantalRotors = new Rotor[5];
            int[] currentRotors = { 1, 2, 3 };

            for (int i = 0; i < aantalRotors.Length; i++)
            {

                aantalRotors[i] = new Rotor();
                aantalRotors[i].myCode = i+1;
                aantalRotors[i].myRotation = 1;
            }

            printRotor();


            void printRotor()
            {
                foreach (Rotor enigmaRotor in aantalRotors)
                {
                    if (currentRotors.Contains(enigmaRotor.myCode))
                    {
                        Console.Write($"[ R{enigmaRotor.myCode} ] ");
                    }

                }

                Console.Write($"\n");
                foreach (Rotor enigmaRotor in aantalRotors)
                {
                    if (currentRotors.Contains(enigmaRotor.myCode))
                    {
                        
                        Console.Write("[ " + String.Format("{0:00}", enigmaRotor.myRotation) + " ] ");
                    }

                }

                Console.Write($"\n");
            }

            Console.ReadLine();
        }

        
    }
}
