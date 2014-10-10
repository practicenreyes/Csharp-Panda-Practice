using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Panda
    {
        public string pName;
        public bool likesHumans;
        public bool likesDogs;
        public bool hasMate;
        public Panda pMate;

        public Panda()
        {

        }

        public Panda(string name)
        {
            pName = name;
        }

        public void PandaMate(Panda mate)
        {
            if (pMate == null)
            {
                pMate = new Panda();
                pMate = mate;
                mate.pMate = this;
                pMate.hasMate = true;
                this.hasMate = true;
            } 
        }
    }
}
