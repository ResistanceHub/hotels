using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearch
{
    public class Hotel
    {
        // these are private fields
        private String name;
        private String rating;
        private String price;

        // this is a public property
        public string Name => name;
        public string Rating => rating;

        public string Price
        {
            get { return price; }
        }

        public Hotel(string name, string rating,string price)
        {         
            this.name = name;
            this.rating = rating;
            this.price = price;
        }

        
    }
}
