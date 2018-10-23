using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Lab11_MVC_App.Models
{
    public class PersonOfYear
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }
        /// <summary>
        /// Get list of time's persons limited by start and end years
        /// </summary>
        /// <param name="startYear">Start year to filter data</param>
        /// <param name="endYear">End year to filter data</param>
        /// <returns>List of persons</returns>
        public static List<PersonOfYear> GetPersons(int startYear, int endYear)
        {
            // initialize empty list of persons
            List<PersonOfYear> people = new List<PersonOfYear>();
            // get current folder for our app
            string path = Environment.CurrentDirectory;
            // combine full path to wwwroot
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\PersonOfTheYear.csv"));
            // read all strings
            string[] myFile = File.ReadAllLines(newPath);

            // for each string
            for (int i = 1; i < myFile.Length; i++)
            {
                // split string into an array by ',' delimiter
                string[] fields = myFile[i].Split(',');
                // add new constructed person object into a resulting list
                people.Add(new PersonOfYear
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }

            // filter the resulting list by start, end years
            List<PersonOfYear> listofPeople = people.Where(p => (p.Year >= startYear) && (p.Year <= endYear)).ToList();
            return listofPeople;
        }
    }
}
