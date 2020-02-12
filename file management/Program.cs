using System;
using System.IO;
using System.Threading.Tasks;

namespace file_management
{
    
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            Console.WriteLine("Login (1) or register (2)?");
            var response = Console.ReadLine();
            if (response == "1")
            {
                bool logined = login(username, password);
                if (logined == true)
                {
                    Console.WriteLine("Succesfully logged in!");
                } else
                {
                    Console.WriteLine("Username/password incorrect!");
                }
            } else if (response == "2")
            {
                register(username, password);

            } else
            {
                Console.WriteLine("Invalid response!");
            }


            

        }  
        static bool login(string username, string password)
        {
            StreamReader ajon = null;
            string r;
            bool found = false;
            try
            {
                ajon = new StreamReader("G:/users.csv");
               
                while (ajon.Peek()!=-1)
                {
                   r=ajon.ReadLine();

                    if (r == $"{username}, {password}")
                    {

                        found = true;
                        
                    } 
                    

                }
                
                
                
                ajon.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error! {err}");
            }


            return found;
        }
        static void register(string username, string password)
        {
            StreamWriter ajon = null;
            try
            {
                ajon = new StreamWriter("G:/users.csv");
                ajon.WriteLine($"{username}, {password}");
                ajon.Close();
                Console.WriteLine("Successfully registered!");
            } catch (Exception err)
            {
                Console.WriteLine($"Error! {err}");
            }
            
        }
    }
}
