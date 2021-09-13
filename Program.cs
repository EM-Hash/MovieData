using System;

namespace MovieData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");  
            
            //Log program start

            //Welcome Message
            //Give the User 3 Options
            //1.) View all the movies
            //2.) Add to the movies
            //Anything else to quit
            
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
                //If it doesn't exist, throw exception and close program
                
                //While there are still lines to read...
                    //Create array of movie values (see How to Parse Data)

                    //Print in format [Title (Genre, Genre, Genre, etc...)]
                    //Print New line

                //Close stream reader


            //Add to Movies
                /* Each movie needs:
                An ID (Must be unique)
                A Title
                Genre(s)
                */

                //Create stream writer

                //Do-While Loop: While user has not given a valid ID...
                    //Prompt user for Movie ID
                    //Check that ID does not yet exist
                        //If it does, tell user that and loop
                        //If it doesn't, break

                //Ask for Title

                //Do-While Loop: While there are more genres to insert...
                    //Prompt user for Genre
                    //Add genre to array
                    //Ask if user would like to add another genre
                        //If so, loop
                        //If not, break

                //Collate information

                //Format: ID,Title**,Genre|Genre|etc....

                //**IF TITLE HAS COMMAS IN IT, PUT QUOTATION MARKS AROUND IT

                //Write to data csv

                //Close stream writer

            //Goodbye message
            //Log program end
        }
    }
}
