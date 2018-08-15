using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Hotels.Models;

namespace Hotels.DataStorage
{
    class FileWriter
    {
        private readonly string _path;
        public FileWriter(string path)
        {
            _path = path;
        }

        public void SaveHotels(List<Hotel> hotels)
        {
            Console.WriteLine("Entering the hotel details in a short while...");

            //using (StreamWriter sw = new StreamWriter("@./Hotel_Information.csv"))
            using (StreamWriter sw = new StreamWriter(_path))
            {

                hotels.ForEach((Hotel hotel) =>
                {
                    //sw.Write(hotel.Name + " , " + hotel.Rating + " , " + hotel.Price + Environment.NewLine);
                    sw.Write($"{hotel.Name}, {hotel.Rating}, {hotel.Price}" + Environment.NewLine);

                });

                //for (int i = 0; i < hotels.Count; i++)
                //{
                //    var currentHotel = hotels[i];
                //    var selectHotelName = currentHotel.Name;
                //    var selectHotelRating = currentHotel.Rating; // _driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > span.rating-box__value")).Text;
                //    var selectHotelPrice = currentHotel.Price; // _driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > strong.item__best-price")).Text;
                //    sw.Write(selectHotelName + " , " + selectHotelRating + " , " + selectHotelPrice + Environment.NewLine);
                //}

                Console.WriteLine("All Hotel details has been written...Congratulations!!!");
            }

        }
    }
}
