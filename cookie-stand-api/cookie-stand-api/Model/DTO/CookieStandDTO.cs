﻿namespace cookie_stand_api.Model.DTO
{
    public class CookieStandDTO
    {
        public int ID { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public List<int> HourlySales { get; set; }

        public int Minimum_Customers_Per_Hour { get; set; }

        public int Maximum_Customers_Per_Hour { get; set; }

        public double Average_Cookies_Per_Sale { get; set; }

        public string Owner { get; set; }

    }


}
