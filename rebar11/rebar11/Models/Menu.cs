using System;
using System.Collections.Generic;

namespace rebar11.Models
{
    public class Menu
    {
        public List<ShakeMenu> Shakes { get; set; }

        public Menu()
        {
            Shakes = new List<ShakeMenu>();
        }

        public List<ShakeMenu> MenuShow()
        {
            return Shakes;
            //הצגת הרשימה של השיקים הקיימים בתפריט
        }

        //public void AddShake(string shakeName, string shakeDescription, int shakeSizeL, int shakeSizeM, int shakeSizeS)
        //{
        //    if (Shakes == null)
        //    {
        //        Shakes = new List<ShakeMenu>();
        //    }
        //    ShakeMenu shake = new ShakeMenu(shakeName, shakeDescription, shakeSizeL, shakeSizeM, shakeSizeS);
        //    Shakes.Add(shake);
        //}
    }
}
