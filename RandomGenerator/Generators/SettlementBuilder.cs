using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RandomGenerator
{
    class SettlementBuilder
    {
        private XDocument reader = XDocument.Load("../../XML/Settlements.xml");

        private ProbabilitySelector relationSelector;
        private ProbabilitySelector rulerSelector;
        private ProbabilitySelector traitSelector;
        private ProbabilitySelector featureSelector;
        private ProbabilitySelector calamitySelector;

        //Populates our probability selectors
        public SettlementBuilder()
        {
            relationSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "RaceRelations"), XDocumentHelper.getProbability(reader, "RaceRelations"));
            rulerSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "RulersStatus"), XDocumentHelper.getProbability(reader, "RulersStatus"));
            traitSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "NotableTraits"), XDocumentHelper.getProbability(reader, "NotableTraits"));
            featureSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "KnownForIts"), XDocumentHelper.getProbability(reader, "KnownForIts"));
            calamitySelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "CurrentCalamity"), XDocumentHelper.getProbability(reader, "CurrentCalamity"));
        }
        //returns a random settlement
        public string randomResult()
        {
            StringBuilder outputString = new StringBuilder();

            outputString.Append("Race Relations: ").Append(relationSelector.rouletteSelect()).AppendLine();
            outputString.Append("Ruler Status: ").Append(rulerSelector.rouletteSelect()).AppendLine();
            outputString.Append("Notable Traits: ").Append(traitSelector.rouletteSelect()).AppendLine();
            outputString.Append("Known for Its: ").Append(featureSelector.rouletteSelect()).AppendLine();
            outputString.Append("Current Issue: ").Append(calamitySelector.rouletteSelect()).AppendLine();
            
            return outputString.ToString();
        }
    }
}
