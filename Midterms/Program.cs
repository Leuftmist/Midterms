using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermsB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> AddressBook = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> AddressBook1 = new Dictionary<string, List<string>>();
            List<string> lists = new List<string>();
            string uinput = "";
            string masterfile = "Masterfile.txt";
            string[] tempvar = new string[] { };
            string deleteinput = "";
            string choiceinput = "";
            bool brother = true;
            bool pog = true;
            int counter = 1;


            if (File.Exists(masterfile))
            {

                using (StreamReader sr = new StreamReader(masterfile))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        lists.Add(line);
                    }

                }

                for(int x = 0; x < lists.Count; x++)
                {
                    using (StreamReader sr = new StreamReader(lists[x] + ".txt"))
                    {
                        string lines = "";
                        List<string> list1 = new List<string>();
                        while ((lines = sr.ReadLine()) != null)
                        {
                            list1.Add(lines);
                            
                        }
                        AddressBook[list1[0]] = list1;
                    }
                    
                }
            }


            while (brother)
            {
                Console.WriteLine("Input 'A' if you want to add entries to the dictionary");
                Console.WriteLine("Input 'B' if you want to view the content of the dictionary");
                Console.WriteLine("Input 'C' if you want to delete an entry in the dictionary");
                Console.WriteLine("Input any other key if you want to proceed");
                uinput = Console.ReadLine();

                if (uinput == "A")
                {
                    bool monka = true;
                    while (monka)
                    {
                        List<string> userinputs = new List<string>();
                        List<string> userinputs1 = new List<string>();
                        userinputs.Add("Last name");
                        userinputs.Add("First name");
                        userinputs.Add("Email");
                        userinputs.Add("Contact number");
                        string uinput1 = "";
                        Console.WriteLine("Do you want to add a Special Category?");
                        uinput1 = Console.ReadLine();
                        if (uinput1 == "Yes")
                        {
                            pog = true;
                            while (pog)
                            {
                                Console.WriteLine("What Special Category would you like to add?");
                                string uinput2 = "";
                                string uinput3 = "";
                                uinput2 = Console.ReadLine();
                                userinputs.Add(uinput2);
                                Console.WriteLine("Would you like to add another special category?");
                                uinput3 = Console.ReadLine();
                                
                                if (uinput3 == "Yes")
                                {
                                    pog = true;
                                }
                                else
                                {
                                    pog = false;
                                }
                            }


                        }
                        for (int x = 0; x < userinputs.Count; x++)
                        {
                            uinput1 = "";
                            Console.Clear();
                            Console.WriteLine("Please enter your " + userinputs[x]);
                            uinput1 = Console.ReadLine();
                            userinputs1.Add(uinput1);
                        }
                        AddressBook[userinputs1[0]] = userinputs1;

                        Console.WriteLine("");
                        string filename = userinputs1[0][0] + "_" + userinputs1[1] + ".txt";
                        
                        if (File.Exists(filename))
                        {

                            using (StreamWriter sw = new StreamWriter(userinputs1[0][0] + "_" + userinputs1[1] + counter + ".txt"))
                            {

                                foreach (string s in userinputs1)
                                {
                                    sw.WriteLine(s);
                                }

                            }
                            counter++;
                        }
                        else
                        {
                            using (StreamWriter sw = new StreamWriter(userinputs1[0][0] + "_" + userinputs1[1] + ".txt"))
                            {

                                foreach (string s in userinputs1)
                                {
                                    sw.WriteLine(s);
                                }

                            }
                        }


                    break;
                    }


                }

                else if (uinput == "B")
                {
                    Console.Clear();
                    List<int> Index = new List<int>();
                    for(int z = 0; z < AddressBook.Count; z++)
                    {
                        Index.Add(z);
                    }
                    for(int x = 0; x < AddressBook.Count -1; x++)
                    {
                        int min = x;
                        for(int y = min + 1; y < AddressBook.Count; y++)
                        {
                            if (string.Compare(AddressBook.ElementAt(y).Key, AddressBook.ElementAt(min).Key) < 0)
                            {
                                min = y;
                            }
                            
                        }
                        if (min != x)
                        {
                            int temp = Index[x];
                            Index[x] = Index[min];
                            Index[min] = temp;
                        }
                    }
                    for(int x = 0; x < AddressBook.Count; x++)
                    {
                        foreach (string list in AddressBook.ElementAt(Index[x]).Value)
                        {
                            Console.Write(list + " ");
                        }
                        Console.WriteLine("");
                    }
                    
                        

                    
                }
                else if (uinput == "C")
                {
                    List<int> Index = new List<int>();
                    for (int z = 0; z < AddressBook.Count; z++)
                    {
                        Index.Add(z);
                    }
                    for (int x = 0; x < AddressBook.Count - 1; x++)
                    {
                        int min = x;
                        for (int y = min + 1; y < AddressBook.Count; y++)
                        {
                            if (string.Compare(AddressBook.ElementAt(y).Key, AddressBook.ElementAt(min).Key) < 0)
                            {
                                min = y;
                            }

                        }
                        if (min != x)
                        {
                            int temp = Index[x];
                            Index[x] = Index[min];
                            Index[min] = temp;
                        }
                    }
                    for (int x = 0; x < AddressBook.Count; x++)
                    {
                        foreach (string list in AddressBook.ElementAt(Index[x]).Value)
                        {
                            Console.Write(list + " ");
                        }
                        Console.WriteLine("");
                    }
                    
                    Console.WriteLine("Enter 1 to delete a single entry or any key to proceed to delete all entries");
                    choiceinput = Console.ReadLine();
                    if (choiceinput == "1")
                    {
                        Console.WriteLine("Please enter the last name of the entry you want to delete");

                        deleteinput = Console.ReadLine();
                        if (AddressBook.ContainsKey(deleteinput))
                        {
                            AddressBook.Remove(deleteinput);
                        }
                        else
                        {
                            Console.WriteLine("Bobo ka ba?");
                        }
                    }
                    else
                    {
                        AddressBook.Clear();
                    }

                }
                else
                {
                    using (StreamWriter sw = new StreamWriter("Masterfile.txt"))
                    {

                        foreach(KeyValuePair<string,List<string>> kvp in AddressBook)
                        {
                            sw.WriteLine(kvp.Key[0] + "_" + kvp.Value[1]);
                            
                        }

                    }
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}