using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;


namespace PasswordGenerator
{
    class Program
    {
        public class variables
        {
            public static string userName;
            public static int passwordLength;
            public static string chars;
            public static char[] stringChars;
            public static string finalString;

        }
        static void Main(string[] args)
        {

            Console.ReadLine();
            welcomeMessage();
            lengthCheck();

            
        }

        static void welcomeMessage()
        {
            Console.WriteLine("Hello, please type your name to continue...");
            bool ok = true;

            do
            {
                try
                {
                    variables.userName = Console.ReadLine();
                    ok = false;
                    if (variables.userName.Length == 0) throw new ApplicationException("Please, type your name!");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Sorry, something went wrong!");
                    ok = true;
                }
                catch(ApplicationException e)
                {
                    Console.WriteLine(e.Message);
                    ok = true;
                }
            } while (ok);

            Console.WriteLine("Welcome, " + variables.userName);
        }

        public static void lengthCheck()
        {

            Console.WriteLine("Please enter the length of your password!");
            bool ok = true;
            do
            {
                try
                {
                    variables.passwordLength = int.Parse(Console.ReadLine());
                    if (variables.passwordLength < 4 || variables.passwordLength > 100) throw new ApplicationException("Your password has to be between 4 and 100 charachters.");
                    
                    ok = false;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter a valid number!");
                    ok = true;
                }
                catch(ApplicationException e)
                {
                    Console.WriteLine(e.Message);
                    ok = true;
                }
            } while (ok);

            Console.WriteLine("Length: " + variables.passwordLength);

            Generate();
        }

        public static void Generate()
        {
            variables.chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            variables.stringChars = new char[variables.passwordLength];
            var random = new Random();
            for (int i = 0; i < variables.stringChars.Length; i++)
            {
                variables.stringChars[i] = variables.chars[random.Next(variables.chars.Length)];
            }

            variables.finalString = new String(variables.stringChars);

            Console.WriteLine(variables.finalString);

            Console.WriteLine("Press Enter to save your password!");
            Console.ReadLine();

            Save();
        }

        public static void Save()
        {
            /*
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.IO.Directory.CreateDirectory(path + @"\SavedPasswords");
            */

            string fileName = @"C:\Saved Passwords\Pw.txt";
            fileName = Path.GetFullPath(fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(fileName));

            

            TextWriter tsw = new StreamWriter(fileName, true);
            


            tsw.WriteLine(variables.userName + " | " + variables.finalString + " | "+  "Length: " + variables.passwordLength);

            tsw.Close();
        }
    }
}
