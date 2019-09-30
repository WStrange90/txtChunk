﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace txtChunkNew
{
    class Program
    {
        static void Main(string[] args)
        {
            printBanner();
            //populateTestFile();

            Console.Write("How many lines would you like the new files to be? ");
            string lengthInput = Console.ReadLine().Trim();
            Console.WriteLine();

            Console.Write("Would you like to replace tabs with another character? (Y/N): ");
            string tabInput = Console.ReadLine().Trim().ToUpper();
            bool tabChoice;
            string newCharacter = "";

            if (tabInput.Equals("Y"))
            {
                Console.WriteLine("You have chosen to replace tabs. What character would you like to use?");
                newCharacter = Console.ReadLine().Trim();
                tabChoice = true;
            }
            else
            {
                tabChoice = false;
            }

            Console.WriteLine("Do the files have a header? (Y/N)");
            Console.WriteLine("Note: All input files must either have a header or none of them may have a header!");
            Console.WriteLine("      Otherwise the output will be incorrect!");
            string headerChoice = Console.ReadLine().Trim().ToUpper();
            bool headerExists = false;

            if (headerChoice.Equals("Y"))
            {
                headerExists = true;
            }


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

            string newDocPath = "Output"; //Prod Value
            string dropZone = "DropZone"; //Prod Value
            //string newDocPath = "../../../Output"; //Debug Value
            //string dropZone = "../../../DropZone"; //Debug Value

            string[] dropZoneFiles = Directory.GetFiles(dropZone, "*.txt");
            foreach (var file in dropZoneFiles)
            {
                string[] fileContents = System.IO.File.ReadAllLines(file);

                string currentFileHeader = "";

                if (headerExists)
                {
                    currentFileHeader = fileContents[0];
                }

                //if (desiredFileLength > fileContents.Length)
                //{
                //    Console.WriteLine("The file '" + Path.GetFileName(file) + "' is not large enough to support the length you entered.");
                //    Console.WriteLine("Press enter to exit.");
                //    Console.ReadLine();
                //    Environment.Exit(0);
                //}

                int currentFileLine = 0;
                int NumOfFilesMade = 0;

                while (currentFileLine < fileContents.Length)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(newDocPath, Path.GetFileNameWithoutExtension(file) + NumOfFilesMade + ".txt")))
                    {
                        for (int i = 0; i < desiredFileLength; i++)
                        {
                            //If the files being processed have headers, write the header at the beggining of every new output file
                            if (headerExists && i == 0 && currentFileLine == 0)
                            {
                                outputFile.WriteLine(currentFileHeader);
                                currentFileLine++;
                                if (currentFileLine == fileContents.Length)
                                {
                                    break;
                                }
                                continue;
                            }
                            else if (headerExists && i == 0)
                            {
                                outputFile.WriteLine(currentFileHeader);
                            }

                            //Change delimiter from tabs to pipes
                            if (tabChoice)
                            {
                                fileContents[currentFileLine] = fileContents[currentFileLine].Replace("\t", newCharacter);

                                //Removes blank lines from the output if they consist of only delimiters
                                if (Regex.Matches(fileContents[currentFileLine], @"[a-zA-Z\d]").Count == 0)
                                {
                                    currentFileLine++;
                                    if (currentFileLine == fileContents.Length)
                                    {
                                        break;
                                    }
                                    continue;
                                }
                            }

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
                Console.WriteLine("The file '" + Path.GetFileName(file) + "' has been proccessed and it can be found in the Output folder.");
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

        public static void populateTestFile()
        {
            using (StreamWriter testFile = new StreamWriter(@"C:\Users\wstrange\Desktop\txtChunk AVX\testTxtChunkFile.txt"))
            {
                for (int i = 1; i <= 6000; i++)
                {
                    testFile.WriteLine("\t" + i + "\t");
                }
            }

        }
    }
    
}
