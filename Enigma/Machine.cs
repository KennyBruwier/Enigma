﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Machine
    // de machine gebruiken

    /* 
     * [ENIGMA MACHINE]
     * 
     * [ R1 ] [ R2 ] [ R3 ]
     * [ 10 ] [ 01 ] [ 01 ]
     * 
     * Input: CIXHNHWGK
     * Output:
     * 
     * press esc to go back
     */

    {
        public string inputMsg { get; set; } = "";
        public string outputMsg { get; private set; } = "";

        public Machine()
        {

        }
    

    }
}
