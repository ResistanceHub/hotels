using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HotelSearch.PageObjects;

namespace HotelSearch
{
    class DataStore
    {
        public static void SaveHotels(List<SearchPage.Hotel> hotels)
        {
            //Save Hotel Name list on screen or into CSV file
            const string path = @"..\..\SearchResult\hotels.csv"; //put reltive path to Debug folder           
            for (var i = 0; i <= hotels.Count - 1; i++)
            {
                var hotel = hotels[i];
                Console.WriteLine($"{i + 1},{hotel.Name}, {hotel.Rating},{hotel.Price}");
            }
            var fs = new FileStream(path, FileMode.Create);
            using (var hotelsResult = new StreamWriter(fs, Encoding.UTF8)
            ) // Get correct encoding format for price, see https://msdn.microsoft.com/en-us/library/72d9f8d5(v=vs.110).aspx
            {
                Console.WriteLine("First Page Hotels");
                Console.WriteLine($"{"ID"}, {"Name"} , {"Rating"} , {"Price"}");

                hotelsResult.WriteLine("First Page Hotels");
                hotelsResult.WriteLine($"{"ID"}, {"Name"} , {"Rating"} , {"Price"}");

                for (var i = 0; i < hotels.Count; i++)
                {
                    SearchPage.Hotel hotel = hotels[i];
                    Console.WriteLine($"{i + 1},{hotel.Name}, {hotel.Rating},{hotel.Price}");
                    hotelsResult.WriteLine($"{i + 1},{hotel.Name},{hotel.Rating},{hotel.Price}");
                }

            }
        }
    }
}
