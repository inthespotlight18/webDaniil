using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class oDog : iAnimal
    {
        bool _Sleep;

        public oDog()
        {
            _Sleep = false;
        }

        public bool Walk()
        {
            if (_Sleep) return false;
            return true;
        }

        public string Speak()
        {
            return "Guf";
        }
    }
          
}
