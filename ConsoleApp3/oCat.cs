using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class oCat : iAnimal
    {
        bool _Sleep;

        public oCat()
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
            return "Meow";
        }
    }
}
