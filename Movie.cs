using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase
{
    //Movie class
    public class Movie
    {
        //Parameters
        public string Title {get; set;}
        public string Category {get; set;}
        public string YearReleased {get; set;}
        public int RunTime {get; set;}
        //Constructor
        public Movie(string _title, string _category, string _yearreleased, int _runtime)
        {
            Title = _title;
            Category = _category;
            YearReleased = _yearreleased;
            RunTime = _runtime;

        }
    }
}