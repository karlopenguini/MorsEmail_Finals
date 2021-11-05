using MorsEmail.Views.Init;
using MorsEmail.Models;
using System;
using System.IO;
using MorsEmail.Datastructures;

namespace MorsEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDirectories();
            MorsEmailAccounts Accounts = new MorsEmailAccounts();
            HeroView Hero = new HeroView(Accounts);
        }

        public static void InitDirectories()
        {
            string pathMain = $@".\accounts";
            try
            {

                if (Directory.Exists(pathMain))
                {

                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(pathMain);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(pathMain));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
