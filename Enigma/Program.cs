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
            Rotor[] aantalRotors = new Rotor[5];
            Plugbox enigmaPlugbox = new Plugbox();
            Enigma enigma = new Enigma();
            enigma = new Enigma();
            // default/start waarden invullen

            int[] currentRotors = { 1, 2, 3 };
            char[] menuKeuzes = { '1', '2', '3', '4' };
            char keyStrike;


            for (int i = 0; i < aantalRotors.Length; i++)
            {
                aantalRotors[i] = new Rotor();
                aantalRotors[i].myCode = i ;

            }

            Console.WriteLine($"Hello! This is an Enigma Machine.\n" +
                                $"Currently your machine is set up like this:\n\n");

            printRotor();
            printPlugbox();


            // menu keuze functie aanmaken

            Console.Write($"\n");
            Console.WriteLine(  $"[1] Use the machine.\n" +
                                $"[2] Change the rotors.\n" +
                                $"[3] Wire the plugbox.\n" +
                                $"[4] Exit the application\n");

            do
            {
                keyStrike = Console.ReadKey().KeyChar;
            }
            while (!menuKeuzes.Contains(keyStrike));

            switch (keyStrike)
            {
                case '1':
                    useMachine();
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;

            }

            void printRotor()
            {
                foreach (Rotor enigmaRotor in enigma.Rotors)
                {
                    if (currentRotors.Contains(enigmaRotor.myCode))
                    {
                        Console.Write($"[ R{enigmaRotor.myCode} ] ");
                    }

                }

                Console.Write("\n");
                foreach (Rotor enigmaRotor in enigma.Rotors)
                {
                    if (currentRotors.Contains(enigmaRotor.myCode))
                    {

                        Console.Write("[ " + String.Format("{0:00}", enigmaRotor.myRotation ) + " ] ");
                    }

                }
                Console.Write("\n");
            }

            void printPlugbox()
            {

                Console.WriteLine("\n");
                Console.WriteLine(enigmaPlugbox.encryptionKeysLeft);

                for (int i = 0; i < enigmaPlugbox.encryptionKeysLeft.Length; i++)
                {
                    if (i != enigmaPlugbox.encryptionKeysLeft.Length - 1)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.WriteLine("|");
                    }
                }
                Console.WriteLine(enigmaPlugbox.encryptionKeysRight);

            }

            void useMachine()
            /* 
            * [ENIGMA MACHINE]
            * 
            * [ R1 ] [ R2 ] [ R3 ]
            * [ 10 ] [ 01 ] [ 01 ]
            * 
            * Input: CIXHNHWGK
            * Output:
            */
            {
                string inputMsg = "";
                string outputMsg = "";

                ConsoleKeyInfo keyinfo;
                do
                {
                    Console.Clear();
                    Console.WriteLine("[ENIGMA MACHINE]\n");

                    printRotor();


                    Console.Write(  "\n" +
                                    $"Input:    {inputMsg}\n" +
                                    $"Output:   {outputMsg}\n\n" +
                                    $"(Esc) key to go back\n");

                    keyinfo = Console.ReadKey(true);
                    inputMsg += Char.ToUpper(keyinfo.KeyChar);
                    outputMsg += enigma.Gebruiken(Char.ToUpper(keyinfo.KeyChar));
                }
                while (keyinfo.Key != ConsoleKey.Escape);

            }

        }


    }
}
