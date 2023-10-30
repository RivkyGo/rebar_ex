using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rebar11.Models
{
    public class Shake
    {
        public string ShakeName { get; set; }
        public string ShakeDescription { get; set; }
        public Guid ShakeID { get; set; }
        public int ShakeSize { get; set; }
        public Guid NewShakeID { get; set; }

        public Shake(string shakeName, string shakeDescription, Guid shakeID, int shakeSize)
        {
            ShakeName = shakeName;
            ShakeDescription = shakeDescription;
            ShakeID = shakeID;
            ShakeSize = shakeSize;
            NewShakeID = Guid.NewGuid();
        }
    }
}
