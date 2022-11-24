using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == LAST.rollNumber)
                    return (true);/*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber)/*If the node is present at the end*/
                return true;
            else
                return (false);/*returns false if the node is not found*/
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        public void traverse()/*Traverses all nodes of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the List are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "  " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + "   " + LAST.name + "\n");
            }
        }
        public void firstnode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n " + LAST.next.rollNumber + "   " + LAST.next.name);
        }
        public void insertionNode()
        {
            int rollNumber;
            string name;
            Console.WriteLine("\nEnter the rollNumber: ");
            rollNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter the name: ");
            name = Console.ReadLine();

            Node newnode = new Node();
            newnode.name = name;
            newnode.rollNumber = rollNumber;

            //Node ditambahkan sebagai node pertama
            if (LAST == null || rollNumber <= LAST.rollNumber)
            {
                if ((LAST == null) && (rollNumber == LAST.rollNumber))
                {
                    Console.WriteLine("\nrollNumber can't be same  ");
                }
                newnode.next = LAST.next;
                LAST.next = newnode;
                LAST = newnode;
                return;
            }
            //Menemukan lokasi node baru didalam list
            Node previous, current;
            previous = LAST;
            current = LAST;

            while ((current != null) && (rollNumber >= current.rollNumber))
            {
                if (rollNumber == current.rollNumber)
                {
                    Console.WriteLine("\nrollNumber not be same  ");
                }
                previous = current;
                current = current.next;
            }
            //Node baru akan ditempatkan di antara previous dan current
            newnode.next = current;
            previous.next = current;
        }
        public bool delNode(int rollNumber)
        {
            Node previous, current;
            previous = current = null;
            //check apakah node yang dimaksud ada didalam list atau tidak
            if (Search(rollNumber, ref previous, ref current) == false)
                return false;
            previous.next = LAST.next; //ganti ini dari ppt
            if (current == LAST)

                LAST = previous; //ganti dari ppt
            return true;
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Add data in the list");
                    Console.WriteLine("5. Deleted data in the list");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("Enter your choice (1-6) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break ;
                        case '3':
                            {
                                obj.firstnode();
                            }
                            break;
                        case '4':
                            {
                                obj.insertionNode();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList Empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student whose delete: ");
                                int nim = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(nim) == false)
                                    Console.WriteLine("\nData not found");
                                else
                                    Console.WriteLine("Data rollnumber  " + nim + "Deleting");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break ;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}