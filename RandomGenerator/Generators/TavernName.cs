using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RandomGenerator
{
    class TavernName
    {
        private XDocument reader = XDocument.Load("../../XML/Taverns.xml");

        private ProbabilitySelector first;
        private ProbabilitySelector second;
        private ProbabilitySelector third;
        private ProbabilitySelector fourth;

        //Populates our probability selectors
        public TavernName()
        {
            first = new ProbabilitySelector(XDocumentHelper.getText(reader, "Specifiers"), XDocumentHelper.getProbability(reader, "Specifiers"));
            second = new ProbabilitySelector(XDocumentHelper.getText(reader, "Verbs"), XDocumentHelper.getProbability(reader, "Verbs"));
            third = new ProbabilitySelector(XDocumentHelper.getText(reader, "Nouns"), XDocumentHelper.getProbability(reader, "Nouns"));
            fourth = new ProbabilitySelector(XDocumentHelper.getText(reader, "Types"), XDocumentHelper.getProbability(reader, "Types"));
        }
        //returns a random tavern name
        public string randomResult()
        {
            return first.rouletteSelect() + " " + second.rouletteSelect() + " " + third.rouletteSelect() + fourth.rouletteSelect();
        }
    }
}
