
//Repo: MovieData
//Author: Emma Meade
//Version: 1.xx

using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;

namespace MovieData
{
    class Program
    {
        static void Main(string[] args)
        {
            //Directory
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";

            // create instance of Logger
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            //Name of the file to read
            string movieFile = "movies.csv";
            
            //Log program start
            logger.Info("Program start");

            //Welcome Message
            Console.WriteLine("Welcome to the Movie Database! Would you like to...");
            //Give the User 3 Options
            //1.) View all the movies
            //2.) Add to the movies
            //Anything else to quit
            Console.WriteLine("1.) View all movies (1)");
            Console.WriteLine("2.) Add a movie (2)");
            Console.WriteLine("3.) Quit (Any character)");
            string ans = Console.ReadLine(); 

            if (ans == "1"){
                logger.Info("View all movies");
                //View all Movies
                /*
                    How to parse data:
                    For each line:
                    IF THERE ARE QUOTATION MARKS
                        Separate by Quotation marks
                        Remove the commas at the end of x[0] and the beginning of x[1]
                            //ex: x[0] = x[0].substring(x[0].length-1); (???), that sort of thing
                    ELSE
                        Separate by Commas Only
                    Separate by Pipes
                */
                //Try to open file w/ stream reader
                try{
                    StreamReader sr = new StreamReader(movieFile);
                    //While there are still lines to read...
                    //Create array of movie values (see How to Parse Data)

                    //Print in format [Title (Genre, Genre, Genre, etc...)]
                    //Print New line

                    //Close stream reader
                    sr.Close();
                } catch(Exception e) {
                    //If it doesn't exist, throw exception and close program
                    logger.Error("File does not exist");
                }
            } else if (ans == "2"){
                logger.Info("Add a movie");
                //Add to Movies
                /* Each movie needs:
                An ID (Must be unique)
                A Title
                Genre(s)
                */
                //Is the ID given valid?
                bool validID = false;
                string movieID;
                do{
                    logger.Info("Start of ID check");
                    //Do-While Loop: While user has not given a valid ID...

                    //Prompt user for Movie ID
                    Console.WriteLine("Please input a Movie ID:");
                    //Take in ID Input
                    movieID = Console.ReadLine();
                    //Check that ID does not yet exist
                        //Start by opening a new reader
                    StreamReader sr = new StreamReader(movieFile);
                    //Cycle through the stream
                    while(!sr.EndOfStream){
                        //Take in the line, parse it based on commas
                        string[] movieLine = sr.ReadLine().Split(",");
                        //If the ID of the movie is equal to what the user put in
                        if (movieLine[0] == movieID){
                            //Tell the user
                            Console.WriteLine("That ID already exists.");
                            //Make the ID false
                            validID = false;
                            //Break out
                            break;
                        } else {
                            //Otherwise, make the ID true
                            validID = true;
                        }
                    }
                    //If the ID is valid
                    if(validID){
                        //Close the stream
                        sr.Close();
                    }
                //Check if the ID is valid. If so, break. If not, repeat with a new ID. 
                } while (!validID);

                logger.Info("Valid ID given");
                
                //Once the user has given a valid ID....

                //Create stream writer
                StreamWriter sw = new StreamWriter(movieFile, true);

                //Ask for Title
                Console.WriteLine("What is the title of the movie?");
                string movieTitle = Console.ReadLine();

                //Boolean for whether there are more genres to add
                bool moreGenres = true;

                //List of genres
                List<string> genres = new List<string>();

                //Do-While Loop: While there are more genres to insert...
                do{
                    logger.Info("Prompting user for genre...");
                    //Prompt user for Genre
                    Console.WriteLine("What is one of the movie's genres?");
                    //Store genre
                    string genre = Console.ReadLine();
                    //If the genre is already in the vector, say so and loop back to the beginning
                    bool validGenre = true;
                    foreach (string s in genres){
                        if (s.ToLower() == genre.ToLower()){
                            Console.WriteLine("That genre is already listed.");
                            validGenre = false;
                            break;
                        }
                    }
                    //If the genre is already in the vector, skip and go back to the beginning
                    if(validGenre){
                        //If the genre isn't in the vector...
                        //Add genre to vector
                        genres.Add(genre);
                    }
                    //Ask if user would like to add another genre
                    Console.WriteLine("Would you like to add another genre? (Y/N): ");
                    ans = Console.ReadLine();
                    if (ans.ToLower() == "y"){
                        //If so, loop
                        moreGenres = true;
                    } else {
                        //If not, break
                        moreGenres = false;
                    }
                } while (moreGenres);

                logger.Info("All genres collected");

                //Collate information
                
                //Check if title has commas in it
                if (movieTitle.Contains(',')){
                    //If the title has commas, add quotation marks to each side
                    movieTitle = "\"" + movieTitle + "\"";
                }

                //Write to data file in format ID,Title,Genre|Genre|Genre, etc...
                
                //String to add in 
                string movieInput = movieID + "," + movieTitle + ",";
                //Iterate through every genre BUT THE LAST ONE
                for (int i = 0; i < genres.Count - 1; i++){
                    //Add the genre plus a |
                    movieInput += genres[i] + "|";
                }
                //Add the last genre
                movieInput += genres[genres.Count-1];

                //Add the string to the csv file
                sw.WriteLine(movieInput);

                //Close stream writer
                sw.Close();
            } else {
                //Quit program, aka do nothing
            }

            //Goodbye message
            //Log program end
            logger.Info("Program end");
        }
    }
}
