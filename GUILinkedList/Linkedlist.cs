using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GUIL
{

    class Linkedlist
    {
        Node head;
        public Linkedlist()
        {
            head = null;
        }
        public void insert(byte dt)
        {
            Node newNode = new Node(dt);
            Node.count++;


            if (head == null)
            {
                head = newNode;
                //Node.index = 0;
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
                // Node.index = Node.count - 1;
            }
        }
        public void insertat(int ind, byte dt)
        {
            Node newNode = new Node(dt);

            if (ind == 0)
            {
                newNode.next = head;
                head = newNode;
                Node.count++;
                return;
            }

            Node current = head;
            int currentPosition = 0;//1<2-1
            while (current != null && currentPosition < ind - 1)
            {
                current = current.next;
                currentPosition++;
            }

            if (current == null)
            {
                Console.WriteLine("Invalid index.");
                return;
            }
            //ind=2
            //{0,1,m,2}

            newNode.next = current.next;
            current.next = newNode;
            Node.count++;
        }

        /*public void remove(byte dt)
        {
            if (head == null)
            {
                return;
            }
            if (head.data == dt)
            {
                head = head.next;
                Node.count--;
                return;
            }
            Node current = head;
            while (current.next != null)
            {
                if (current.next.data == dt)
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
            }
            Node.count--;
        }*/
        public void removebyindex(int ind)
        {
            if (head == null)
            {
                return;
            }
            bool flag = true;
            int z = 0;
            while (flag)
            {
                if (ind == z)
                {
                    head = head.next;
                    Node.count--;
                    // Node.index--;
                    flag = false;
                    return;
                }
                Node current = head;
                while (current.next != null)
                {
                    z++;
                    if (z == ind)
                    {
                        current.next = current.next.next;
                        // Node.index--;
                        Node.count--;
                        flag = false;
                        return;
                    }
                    current = current.next;
                }
                Node.count--;
            }
        }
        public void search(int ind)
        {

            Node current = head;
            int z = 0;
            while (current != null)
            {
                if (z == ind)
                {
                    Console.Write(current.data + "(index: " + z + ")");
                    return;
                }
                current = current.next;
                z++;
            }
            Console.Write("Not found.");

        }

        public void print()
        {
            Node current = head;
            int x = 0;
            while (current != null)
            {

                Console.Write(current.data + "(index: " + x + ")->");
                current = current.next;
                x++;
            }
            Console.WriteLine();

        }
    }



}
