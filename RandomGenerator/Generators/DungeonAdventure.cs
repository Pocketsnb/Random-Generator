using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RandomGenerator
{
    class DungeonAdventure
    {
        private XDocument reader = XDocument.Load("../../XML/Dungeons.xml");

        private ProbabilitySelector locationSelector;
        private ProbabilitySelector creatorSelector;
        private ProbabilitySelector alignmentSelector;
        private ProbabilitySelector classSelector;
        private ProbabilitySelector purposeSelector;
        private ProbabilitySelector historySelector;
        private List<string> purposeText;
        private List<string> purposeDesc;

        //Populates our probability selectors and purpose descriptions
        public DungeonAdventure()
        {
            locationSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Locations"), XDocumentHelper.getProbability(reader, "Locations"));
            creatorSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Creators"), XDocumentHelper.getProbability(reader, "Creators"));
            alignmentSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Alignments"), XDocumentHelper.getProbability(reader, "Alignments"));
            classSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Classes"), XDocumentHelper.getProbability(reader, "Classes"));
            purposeText = XDocumentHelper.getText(reader, "Purposes");
            purposeSelector = new ProbabilitySelector(purposeText, XDocumentHelper.getProbability(reader, "Purposes"));
            historySelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Histories"), XDocumentHelper.getProbability(reader, "Histories"));
            purposeDesc = XDocumentHelper.getDescription(reader, "Purposes", "Description");
        }
        //returns a random dungeon
        public string randomResult()
        {
            StringBuilder outputString = new StringBuilder();

            outputString.Append(locationSelector.rouletteSelect()).Append(", created by ");

            //additional work for alignment and class for "Humans" creator
            string creator = creatorSelector.rouletteSelect();
            if(creator.Equals("Humans"))
            {
                outputString.Append(alignmentSelector.rouletteSelect()).Append(" ").Append(classSelector.rouletteSelect()).Append(" ");
            }
            outputString.Append(creator).Append(", this dungeon is a ");

            string purpose = purposeSelector.rouletteSelect();
            outputString.Append(purpose).Append(". ");

            //maps purpose description to the purpose chosen based on index position
            string purposeDescription = purposeDesc[purposeText.IndexOf(purpose)];
            outputString.Append(purposeDescription).Append(" Additional details: ").Append(historySelector.rouletteSelect()).Append(".");

            return outputString.ToString();
        }
    }
}
