using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat11
{
    public class Tundra: Elovilag
    {
        private static Tundra? instance= null;

        private Tundra(): base()
        { }
        public static Tundra Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Tundra();
                }
                return instance;
            }
        }
    }
}
