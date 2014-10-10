using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Zoo
    {
        public Zoo()
        {

        }

        public Zoo(string zooname)
        {
            _pandas = new List<Panda>();
            _zooName = zooname;
        }

        public string ZooName
        {
            get { return _zooName; }
        }

        public void NewPanda(Panda panda)
        {
            _pandas.Add(panda);
        }

        public List<string> PandaNames()
        {
            List<string> names = new List<string>();

            foreach (var panda in _pandas)
            {
                names.Add(panda.pName);
            }

            return names;
        }

        public ZooStats Stats()
        {
            ZooStats stats = new ZooStats();
            stats.PandaQuantity = _pandas.Count;

            foreach (var panda in _pandas)
            {
                if (panda.hasMate == true)
                {
                    stats.MarryedPandas += 1;
                }
                else
                {
                    stats.SinglePandas += 1;
                }

                if (panda.likesHumans == true)
                {
                    stats.likesHuman += 1;
                }

                if (panda.likesDogs == true)
                {
                    stats.likesDogs += 1;
                }
            }

            return stats;
        }

        public Panda SearchPanda(string name)
        {
            Panda Panda = new Panda();

            foreach (var panda in _pandas)
            {
                if (panda.pName == name)
                {
                    Panda = panda;
                }
            }

            return Panda;
        }

        string _zooName;
        List<Panda> _pandas;
    }
}
