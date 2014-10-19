using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dllconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DLList dlList = new DLList();
            dlList.addData(3);
            dlList.addData(6);
            dlList.addData(9);
            dlList.addData(7);
            dlList.addData(4);
            dlList.addData(0);
            dlList.addData(43);
            dlList.addData(6);
            dlList.addData(4);
            dlList.addData(4);
            dlList.addData(4);
            dlList.addData(5);

            // print data method in dlList
            dlList.printData();

            // Keep the console window open
            Console.WriteLine("Press the any key to exit.");
            Console.ReadKey();
        }


    }

    public class DLList
    {
        static node head;
        node n;
        node cursor;

        public DLList() {}

        public void addData(int pData)
        {
            n = new node();
            n.data = pData;

            if (head == null)
            {
                head = n;
                head.prev = null;
            }
           // there is only a head, so add a node to head
            else if (head.next == null)
            {
                if (head.data <= n.data) { n.prev = head; head.next = n; n.next = null; }
            }
            else if (head.data > n.data)
            {
                n.next = head;
                head.prev = n;
                head = n;
            }
            // head is not null, traverse the list to add data
            else
            {
                // traverse starting from head
                cursor = head;

                // check if value needs to be inserted before head
                if (cursor.data > n.data)
                {
                    insertNode();
                    head = n;
                }
                // if not, start traversing the list, unless tail is reached:
                while (cursor.next != null)
                {
                    // check if new node needs to be inserted, if not, continue traversing
                    if (cursor.data <= n.data)
                    {
                        cursor = cursor.next;
                    }
                    // if it is, insert node
                    else
                    {
                        insertNode();
                        break;
                    }
                }
                // check if tail is reached, if so, decide were to put new node
                if (cursor.next == null)
                {
                    // new node needs to be appended
                    if (cursor.data <= n.data)
                    {
                        appendNode();
                    }
                    // new node needs to be inserted
                    else
                    {
                        insertNode();
                    }
                }
            }
        }

        private void appendNode()
        {
            cursor.next = n;
            n.prev = cursor;
            cursor = n;
        }

        private void insertNode()
        {
            n.next = cursor;
            cursor = cursor.prev;
            cursor.next = n;
            n.prev = cursor;
            cursor = cursor.next;
            cursor = cursor.next;
            cursor.prev = n;
        }
        public void printData()
        {
            cursor = head;
            while (cursor != null)
            {
                Console.Write(Convert.ToString(cursor.data) + " ");
                cursor = cursor.next;
            }
            Console.WriteLine();
        }
        class node
        {
            public node prev;
            public int data;
            public node next;
        }
    }
}
