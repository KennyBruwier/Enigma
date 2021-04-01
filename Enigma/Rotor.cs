using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Enigma
    {
        private int[] selectedRotors = new int[3];
        public Rotor[] Rotors { get; set; }
        public Stecker StekkerDoos { get; set; }
        public Spiegel Spiegel { get; set; }
        public Enigma()
        {
            Opstarten();
        }
        void Opstarten()
        {
            Rotors = new Rotor[5];
            for (int i = 0; i < 5; i++)
            {
                Rotors[i] = new Rotor();
                if (i < 3) Rotors[i].myCode = i+1;
                Rotors[i].EncryptionIndex = (byte)i;
            }
            StekkerDoos = new Stecker();
            Spiegel = new Spiegel();
        }
        public char Gebruiken(char cIn)
        {
            char cOut = StekkerDoos.UseReflector(cIn);
            if (cIn == ' ')
            {
                string temp = "";
            }
            FindSelectedRotors();
            RotorsKeyStrike();
            for (int i = 0; i < selectedRotors.GetLength(0); i++)
            {
                cOut = Rotors[selectedRotors[i]].RotorGebruiken(cOut);
                if (cOut == ' ')
                {
                    string temp = "";
                }
            }
            cOut = Spiegel.SpiegelGebruiken(cOut);
            if (cOut == ' ')
            {
                string temp = "";
            }
            for (int i = 0; i < selectedRotors.GetLength(0); i++)
            {
                cOut = Rotors[selectedRotors[selectedRotors.GetLength(0)-1-i]].RotorGebruiken(cOut);
                if (cOut == ' ')
                {
                    string temp = "";
                }
            }
            return StekkerDoos.UseReflector(cOut);
        }
        private void FindSelectedRotors()
        {
            for (int i = 0; i < Rotors.GetLength(0); i++)
            {
                switch (Rotors[i].myCode)
                {
                    case 1:
                        selectedRotors[0] = i;
                        break;
                    case 2:
                        selectedRotors[1] = i;
                        break;
                    case 3:
                        selectedRotors[2] = i;
                        break;
                }
            }
        }
        private void RotorsKeyStrike()
        {
            if ((Rotors[selectedRotors[0]].myRotation + 1) == 26)
            {
                if ((Rotors[selectedRotors[1]].myRotation + 1) == 26)
                {
                    if ((Rotors[selectedRotors[2]].myRotation + 1) == 26)
                    {
                        Rotors[selectedRotors[0]].myRotation = 1;
                        Rotors[selectedRotors[1]].myRotation = 1;
                        Rotors[selectedRotors[2]].myRotation = 1;
                    }
                    else
                    {
                        Rotors[selectedRotors[2]].myRotation++;
                        Rotors[selectedRotors[1]].myRotation = 0;
                    }
                }
                else
                {
                    Rotors[selectedRotors[1]].myRotation++;
                    Rotors[selectedRotors[0]].myRotation = 0;
                }
            }
            else Rotors[selectedRotors[0]].myRotation++;
        }
    }
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
        public byte EncryptionIndex { get; set; } = 0;
        public int myCode { get; set; } = -1;
        public int myRotation { get; set; } = 1;
        public string[] EncryptionKeysLeft { get; set; }
        public string[] EncryptionKeysRight { get; set; }
        public Rotor()
        {
            EncryptionKeysLeft = new string[5] {    "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" };
            EncryptionKeysRight = new string[5] {   "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "AJDKSIRUXBLHWTMCQGZNPYFVOE", "BDFHJLCPRTXVZNYEIWGAKMUSQO", "ESOVPZJAYQUIRHXLNFTGKDCMWB", "VZBRGITYUPSDNHLXAWMJQOFECK" };
        }
        public char RotorGebruiken (char cIn)
        {
            if (EncryptionIndex < EncryptionKeysLeft.GetLength(0))
            {
                string encryptionKeysRight = EncryptionKeysRight[EncryptionIndex];
                string encryptionKeysLeft = EncryptionKeysLeft[EncryptionIndex];

                //if (myRotation < EncryptionKeysRight[EncryptionIndex].Length)
                //{
                //    //encryptionKeysRight = EncryptionKeysRight[EncryptionIndex].Substring(myRotation-1) + EncryptionKeysRight[EncryptionIndex].Substring(0, myRotation-1);
                //    //encryptionKeysLeft  = EncryptionKeysLeft[EncryptionIndex].Substring(myRotation -1) + EncryptionKeysLeft[EncryptionIndex].Substring(0, myRotation -1);
                //}
                //else
                //    myRotation = 0;

                char nIn = MoveChar(cIn, myRotation-1);
                for (int i = 0; i < encryptionKeysLeft.Length; i++)
                {
                    if (nIn == encryptionKeysLeft[i])
                    {
                        char tempc = encryptionKeysRight[i];
                        return MoveChar(encryptionKeysRight[i],(0-myRotation+1));
                    }
                }
            }
            return ' ';
        }
        private char MoveChar(char cIn, int iPos)
        {
            if ((cIn + iPos) > 'Z')
                if ((cIn + iPos < 'A'))
                    return Convert.ToChar('Z' - ('A' - cIn + iPos));
                else
                    return Convert.ToChar('A' + (cIn + iPos - 'Z'));
            else return Convert.ToChar(cIn + iPos);
        }
        public void IncreaseRotation()
        {

        }
    }
    public class Stecker 
    {
        public string EncryptionKeysLeft { get; set; }
        public string EncryptionKeysRight { get; set; }
        public Stecker()
        {
            EncryptionKeysLeft  = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            EncryptionKeysRight = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        public void Omwisselen(char cIn, char cOut)
        {
            string encryptionKeysRight = "";
            cIn = Char.ToUpper(cIn);
            cOut = Char.ToUpper(cOut);
            for (int i = 0; i < EncryptionKeysLeft.Length; i++)
            {
                if (cIn == EncryptionKeysLeft[i])
                {
                    encryptionKeysRight += cOut;
                }
                else
                    encryptionKeysRight += EncryptionKeysLeft[i];
            }
            EncryptionKeysRight = encryptionKeysRight;
        }
        public char UseReflector(char cIn)
        {
            char upperChar = Char.ToUpper(cIn);
            for (int i = 0; i < EncryptionKeysLeft.Length; i++)
            {
                if (upperChar == EncryptionKeysLeft[i])
                    return EncryptionKeysRight[i];
            }
            return ' ';
        }
        public void Reset()
        {
            EncryptionKeysLeft = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            EncryptionKeysRight = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
    }
    public class Spiegel 
    {
        private Reflector[] Reflectors = new Reflector[2];
        public Spiegel()
        {
            Reflectors[0] = new Reflector();
            Reflectors[0].Naam = "Reflector B";
            Reflectors[0].EncryptionKeysLeft   = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Reflectors[0].EncryptionKeysRight  = "ARUHQSLDPXNGOKMIEBFZCWVJYT";
            Reflectors[1] = new Reflector();
            Reflectors[1].Naam = "Reflector C";
            Reflectors[1].EncryptionKeysLeft   = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Reflectors[1].EncryptionKeysRight  = "FVPJIAOYEDRZXWGCTKUQSBNMHL";
        }
        public char SpiegelGebruiken (char cIn)
        {
            char reflect = ' ';
            for (int i = 0; i < Reflectors.GetLength(0); i++)
            {
                if ((reflect = Reflectors[i].UseReflector(cIn)) != ' ') break;
            }
            return reflect;
        }
    }
    class Reflector : Stecker
    {
        public string Naam { get; set; }
        //public string EncryptionKeysLeft { get; set; }
        //public string EncryptionKeysRight { get; set; }
        //public char UseReflector(char cIn)
        //{
        //    for (int i = 0; i < EncryptionKeysLeft.Length; i++)
        //    {
        //        if (Char.ToUpper(cIn) == EncryptionKeysLeft[i])
        //        {
        //            return EncryptionKeysRight[i];
        //        }
        //    }
        //    return ' ';
        //}
        //public void Swap(char a, char b)
        //{
        //    int iLength = EncryptionKeysLeft.Length;
        //    string newRightEncryption = "";
        //    if (iLength > 0)
        //    {
        //        for (int i = 0; i < iLength; i++)
        //        {

        //            if (EncryptionKeysLeft[i] == a)
        //                newRightEncryption += Char.ToUpper(b);
        //            else
        //                if (EncryptionKeysLeft[i] == b)
        //                    newRightEncryption += Char.ToUpper(a);
        //                else
        //                    newRightEncryption += EncryptionKeysRight[i];
        //        }
        //        EncryptionKeysRight = newRightEncryption;
        //    }
        //}

    }

}
