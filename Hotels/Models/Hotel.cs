using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Models
{
    class Hotel
    {
        private readonly string _name;
        private readonly string _price;
        private readonly float _rating;

        public string Name
        {
            get { return _name; }
        }

        public string Price
        {
            get { return _price; }
        }

        public float Rating
        {
            get { return _rating; }
        }

        public Hotel(string name, float rating, string price)
        {
            _name = name;
            _rating = rating;
            _price = price;
        }

        
    }
}
