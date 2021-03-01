using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Rotor
    {
        /* Change the rotors 
         * 
         * [ R1 ] [ R2 ] [ R3 ]
         * [ 01 ] [ 01 ] [ 01 ]
         * 
         * Would you like to use the setup wizard or the quick notation?
         * 
         * [1] Setup wizard.
         * [2] Quick notation.
         * [3] Nothing.
         * 
         *  [1] Setup wizard
         * 
         *  Pick 3 different rotor pieces.
         * 
         *  [1] Rotor 1.
         *  [2] Rotor 2.
         *  [3] Rotor 3.
         *  [4] Rotor 4.
         *  [5] Rotor 5.
         * 
         *  <strike numberkeys>
         * 
         *  Well done. The rotors are set in place.
         *  Here is a quick recap:
         *  - The 1st rotor is 3, and is set to number 1.
         *  - The 2nd rotor is 4, and is set to number 1.
         *  - The 3rd rotor is 5, and is set to number 1.
         * 
         *  [2] Quick notation.
         *  
         *  Welcome to the Quick Setup.
         *  Write the setup like this: [R1].[R2].[R3].[N1].[N2].[N3]
         *  Example: 5.2.3.13.4.17
         *  Input:
         */
        public int myCode { get; set; } = -1;
        public int myRotation { get; set; } = 0;
        public string[] encryptionKeysLeft { get; set; }
        public string[] encryptionKeysRight { get; set; }

        public Rotor()
        {
            encryptionKeysLeft = new string[5] { "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" };
            encryptionKeysRight = new string[5] { "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" };
        }
    }
}
