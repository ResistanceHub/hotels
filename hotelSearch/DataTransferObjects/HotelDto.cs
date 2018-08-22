using System;

namespace HotelSearch.DataTransferObjects
{
    public class HotelDto
    {
        // these are private fields
        private String _name;
        private String _rating;
        private String _price;

        // this is a public property
        public string Name => _name;
        public string Rating => _rating;
        public string Price => _price;

        public HotelDto(string name, string rating, string price)
        {
            _name = name;
            _rating = rating;
            _price = price;
        }
    }
}