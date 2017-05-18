using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RandomGenerator
{
    class TreasureGenerator
    {
        private XDocument readerTreasure = XDocument.Load("../../XML/Treasures.xml");
        private XDocument readerMagic = XDocument.Load("../../XML/MagicItems.xml");
        private ProbabilitySelector treasureSelector;
        
        //Populates our probability selectors and purpose descriptions
        public TreasureGenerator()
        {

        }
        //returns a random individual treasure
        public string randomResult(string treasureType, string levelRange)
        {
            if (levelRange.Equals("17+"))
                levelRange = levelRange.Remove(2);
            StringBuilder output = new StringBuilder();
            string elementPosition = treasureType + "Treasure" + levelRange;
            treasureSelector = new ProbabilitySelector(XDocumentHelper.getText(readerTreasure, elementPosition), 
                                                       XDocumentHelper.getProbability(readerTreasure, elementPosition));

            string currentTable = treasureSelector.rouletteSelect();

            //get coins from treasure
            List<Dice> coins = XDocumentHelper.getCoins(readerTreasure, elementPosition, currentTable);
            Dictionary<string, int> finalCoins = RandomHelper.RollRandomItem(coins);
            foreach (var coin in finalCoins)
            {
                output.Append(coin.Value + coin.Key).AppendLine();
            }

            //additional work for hoard treasure
            if(treasureType.Equals("Hoard"))
            {
                output.AppendLine();
                Dictionary<string, int> finalItems = new Dictionary<string, int>();

                Dictionary<string, Dictionary<string, string>> objects = new Dictionary<string, Dictionary<string, string>>();
                List<Dice> gems = XDocumentHelper.getTreasure(readerTreasure, elementPosition, currentTable, "Gems");
                List<Dice> art = XDocumentHelper.getTreasure(readerTreasure, elementPosition, currentTable, "Art");
                List<Dice> magic = XDocumentHelper.getTreasure(readerTreasure, elementPosition, currentTable, "Magic");

                output.Append(ItemGetter(RandomHelper.RollRandomItem(gems), readerTreasure));
                output.Append(ItemGetter(RandomHelper.RollRandomItem(art), readerTreasure));
                output.AppendLine().Append(ItemGetter(RandomHelper.RollRandomItem(magic), readerMagic));
            }
            
            return output.ToString();
        }
        public string ItemGetter(Dictionary<string, int> items, XDocument doc)
        {
            StringBuilder output = new StringBuilder();
            foreach (var item in items)
            {
                bool isGems = item.Key.StartsWith("Gems");
                output.Append(item.Value + " " + item.Key + ":").AppendLine();
                List<string> currentItemText = XDocumentHelper.getText(doc, item.Key);
                List<string> gemDesc = new List<string>();
                ProbabilitySelector currentItemSelector = new ProbabilitySelector(currentItemText, XDocumentHelper.getProbability(doc, item.Key));

                if (isGems)
                    gemDesc = XDocumentHelper.getDescription(doc, item.Key, "Description");

                for (int i = 0; i < item.Value; i++)
                {
                    string currentItem = currentItemSelector.rouletteSelect();
                    output.Append(currentItem);
                    if (isGems)
                        output.Append(": " + gemDesc[currentItemText.IndexOf(currentItem)]);
                    output.AppendLine();
                }
            }

            return output.ToString();
        }
    }
}
