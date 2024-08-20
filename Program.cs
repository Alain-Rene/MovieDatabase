// See https://aka.ms/new-console-template for more information
using MovieDatabase;

Console.WriteLine("Hello, World!");

List<Movie> movies = new List<Movie>()
{
    new Movie("The Dark Knight", "Action"),
    new Movie("Pulp Fiction", "Drama"),
    new Movie("The Godfather", "Drama"),
    new Movie("The Matrix", "Action"),
    new Movie("Toy Story" , "Family"),
    new Movie("Forrest Gump", "Drama"),
    new Movie("Spirited Away", "Fantasy"),
    new Movie("The Lord of the Rings", "Fantasy"),
    new Movie("The Lion King", "Family"),
    new Movie("Mulan", "Family"),
    new Movie ("Interstellar", "SciFi"),
    new Movie("Star Wars", "SciFi")

};


int userInput;
bool runProgram = true;
System.Console.WriteLine("Welcome to the movie database!");

//Distinct by linq statement, grabs each individual item
//Distinct by category, will choose every single category
List<String> availableGenres = movies.Select(m => m.Category).Distinct().ToList();

List<Movie> sortedMovies = new List<Movie>();
do
{
    System.Console.WriteLine("Here are the genres of movies we have:");
    for (int i = 0; i < availableGenres.Count; i++)
    {
        System.Console.WriteLine($"{i + 1}. {availableGenres[i]}");
    }

    System.Console.WriteLine("Please choose a genre by number:");

    userInput = int.Parse(Console.ReadLine());

    string genreChoice = availableGenres[userInput - 1];
    //.Any, sees if any are the same category
    System.Console.WriteLine("This is the genre choice: " + genreChoice);

    sortedMovies = movies.Where(m => m.Category == genreChoice)
    .OrderBy(m => m.Title)
    .ToList();

    foreach (Movie m in sortedMovies)
    {
        System.Console.WriteLine(m.Title);
    }
    runProgram = QuestionUser(runProgram);

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

