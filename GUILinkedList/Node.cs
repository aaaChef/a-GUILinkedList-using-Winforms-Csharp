using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIL
{
    class Node
    {
        public byte data;
        public Node next;
        // public static int index;
        public static int count = 0;
        public Node(byte x)
        {
            data = x;
            next = null;
        }
    }
}
