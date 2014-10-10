using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class State
    {
        public State()
        {
            LocalZoos = new List<Zoo>();
        }

        public void AddZoo(Zoo zoo)
        {
            if (zoo != null)
            {
                LocalZoos.Add(zoo);
            }
        }

        public Zoo SearchZoo(string name)
        {
            Zoo sZoo = new Zoo();

            foreach (Zoo zoo in LocalZoos)
            {
                if (zoo.ZooName == name)
                {
                    sZoo = zoo;
                }
            }

            return sZoo;
        }

        public List<string> ZooNames()
        {
            List<string> names = new List<string>();

            foreach (Zoo zoo in LocalZoos)
            {
                names.Add(zoo.ZooName);
            }

            return names;
        }


        List<Zoo> LocalZoos;
    }
}
