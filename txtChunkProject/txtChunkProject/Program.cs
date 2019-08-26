using System;
using System.IO;

namespace txtChunkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            printBanner();

            Console.Write("How many lines would you like the new files to be? ");
            string lengthInput = Console.ReadLine().Trim();

            int desiredFileLength;
            try
            {
                desiredFileLength = Int32.Parse(lengthInput);

                if (desiredFileLength < 1)
                {
                    Console.WriteLine("You entered a number smaller than 1 as your desired file length. This is not possible.");
                    Console.WriteLine("Please enter a whole number larger than 0.");
                    Console.WriteLine("Press enter to exit.");
                    Environment.Exit(0);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to parse input. Are you sure you input a number?");
                throw;
            }

            string newDocPath = "Output"; //Debug Value: "../../../Output"
            string dropZone = "DropZone"; //Debug Value: "../../../DropZone"
            string[] dropZoneFiles = Directory.GetFiles(dropZone, "*.txt");
            foreach (var file in dropZoneFiles)
            {
                string[] fileContents = System.IO.File.ReadAllLines(file);

                if (desiredFileLength > fileContents.Length)
                {
                    Console.WriteLine("The file '" + Path.GetFileName(file) + "' is not large enough to support the length you entered.");
                    Console.WriteLine("Press enter to exit.");
                    Environment.Exit(0);
                }

                int currentFileLine = 0;
                int NumOfFilesMade = 0;

                while (currentFileLine < fileContents.Length)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(newDocPath, Path.GetFileNameWithoutExtension(file) + NumOfFilesMade + ".txt")))
                    {
                        for (int i = 0; i < desiredFileLength; i++)
                        {
                            outputFile.WriteLine(fileContents[currentFileLine]);
                            currentFileLine++;

                            if (currentFileLine == fileContents.Length)
                            {
                                break;
                            }
                        }

                        NumOfFilesMade++;
                    }
                }
                //END While

                Console.WriteLine();
                Console.WriteLine("The file '" + Path.GetFileName(file) + "' has been divided into smaller files and those can be found in the Output folder.");
            }
            //END foreach file

            Console.WriteLine();
            Console.WriteLine("All files from the DropZone folder have been proccessed. Press enter to exit the program.");
            Console.ReadLine();
        }

        public static void printBanner()
        {
            Console.WriteLine(" _______  __   __  _______    _______  __   __  __   __  __    _  ___   _ ");
            Console.WriteLine("|       ||  |_|  ||       |  |       ||  | |  ||  | |  ||  |  | ||   | | |");
            Console.WriteLine("|_     _||       ||_     _|  |       ||  |_|  ||  | |  ||   |_| ||   |_| |");
            Console.WriteLine("  |   |  |       |  |   |    |       ||       ||  |_|  ||       ||      _|");
            Console.WriteLine("  |   |   |     |   |   |    |      _||       ||       ||  _    ||     |_ ");
            Console.WriteLine("  |   |  |   _   |  |   |    |     |_ |   _   ||       || | |   ||    _  |");
            Console.WriteLine("  |___|  |__| |__|  |___|    |_______||__| |__||_______||_|  |__||___| |_|");
            Console.WriteLine();
        }
    }
}
