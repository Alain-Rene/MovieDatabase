/*
Program that takes a list of movies and displays them by category. User can input
any category to display the films that match said category.
*/
using MovieDatabase;

//Movie list using parameters from Movie class
List<Movie> movies = new List<Movie>()
{
    new Movie("The Dark Knight", "Action", "2008", 152),
    new Movie("Pulp Fiction", "Drama", "1994", 154),
    new Movie("The Godfather", "Drama", "1972", 175),
    new Movie("The Matrix", "Action", "1999", 136),
    new Movie("Toy Story" , "Family", "1995", 81),
    new Movie("Forrest Gump", "Drama", "1994", 142),
    new Movie("Spirited Away", "Fantasy", "2001", 125),
    new Movie("The Lord of the Rings", "Fantasy", "2001" , 178),
    new Movie("The Lion King", "Family", "1998", 87),
    new Movie("Mulan", "Family", "2014", 169),
    new Movie ("Interstellar", "SciFi", "2014", 169),
    new Movie("Star Wars", "SciFi", "1977", 121)
};


int userInput;
bool runProgram = true;
System.Console.WriteLine("Welcome to the movie database!");

//Distinct by linq statement, grabs each individual item
//Distinct by category, will choose every single category
List<String> availableGenres = movies.Select(m => m.Category).Distinct().ToList();

//Keeps track of sorted movies for display
List<Movie> sortedMovies = new List<Movie>();
do
{
    System.Console.WriteLine("Here are the genres of movies we have:");

    //Displays a list of all the available categories that the user can choose from
    for (int i = 0; i < availableGenres.Count; i++)
    {
        System.Console.WriteLine($"{i + 1}. {availableGenres[i]}");
    }

    System.Console.WriteLine("Please choose a genre by number:");
    
    userInput = int.Parse(Console.ReadLine());
   
    //Validate input
    if (userInput >= 1 && userInput <= availableGenres.Count)
    {
        string genreChoice = availableGenres[userInput - 1];

        //Use linq to sort the movies
        sortedMovies = movies.Where(m => m.Category == genreChoice)
        .OrderBy(m => m.Title)
        .ToList();

        //Output the movie title, release year and runtime from the sorted list
        foreach (Movie m in sortedMovies)
        {
            System.Console.WriteLine($"{m.Title}, {m.YearReleased}, {m.RunTime} minutes");
        }
        runProgram = QuestionUser(runProgram);
    }
    else
    {
        System.Console.WriteLine($"Invalid input, please enter a number from 1 to {availableGenres.Count}");
    }
    

} while (runProgram);

static bool QuestionUser(bool answer){
    while(true){
        System.Console.WriteLine("Would you like to continue? Please enter yes or no");
        string choice = Console.ReadLine();
        if (choice.ToLower().Trim() == "yes"){
            answer = true;
            break;
        } 
        else if (choice.ToLower().Trim() == "no"){
            answer = false;
            break;
        } 
        else {
            System.Console.WriteLine("Invalid response");
        }
    }
    return answer;
}

