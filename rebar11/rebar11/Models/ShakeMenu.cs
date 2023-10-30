using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rebar11.Models
{
    public class ShakeMenu
    {
        public string ShakeName { get; set; }
        public string ShakeDescription { get; set; }
        public int ShakeSizeL { get; set; }
        public int ShakeSizeM { get; set; }
        public int ShakeSizeS { get; set; }
        public Guid ShakeID { get; set; }

        public ShakeMenu(string shakeName, string shakeDescription, int shakeSizeL, int shakeSizeM, int shakeSizeS)
        {
            ShakeName = shakeName;
            ShakeDescription = shakeDescription;
            ShakeSizeL = shakeSizeL;
            ShakeSizeM = shakeSizeM;
            ShakeSizeS = shakeSizeS;
            ShakeID = Guid.NewGuid();
        }
    }
}
