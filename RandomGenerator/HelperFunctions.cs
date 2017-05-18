using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RandomGenerator
{
    public struct Dice
    {
        public string objectType;
        public int dieCount;
        public int dieType;
        public int dieMultiplier;

        public Dice(string objectType, int dieCount, int dieType, int dieMultiplier)
        {
            this.objectType = objectType;
            this.dieCount = dieCount;
            this.dieType = dieType;
            this.dieMultiplier = dieMultiplier;
        }
    }
    class XDocumentHelper
    {
        //parses the supplied doc for the given Attribute within the Value element for a specified elementName
        public static List<string> getStringAttribute(XDocument doc, string elementName, string attributeName)
        {
            List<string> tempList = doc.Descendants(elementName).Descendants("Value").Select(e => e.Attribute(attributeName).Value).ToList<string>();
            return tempList;
        }
        public static List<int> getIntAttribute(XDocument doc, string elementName, string attributeName)
        {
            List<int> tempList = doc.Descendants(elementName).Descendants("Value").Select(e => int.Parse(e.Attribute(attributeName).Value)).ToList<int>();
            return tempList;
        }
        //parses the supplied doc for the Text field within the Value element for a specified elementName
        public static List<string> getText(XDocument doc, string elementName)
        {
            return getStringAttribute(doc, elementName, "Text");
        }
        //parses the supplied doc for the Probability field within the Value element for a specified elementName
        public static List<int> getProbability(XDocument doc, string elementName)
        {
            return getIntAttribute(doc, elementName, "Probability");
        }
        //parses the supplied doc for the specified descriptionName text field within the Value element for a specified elementName
        public static List<string> getDescription(XDocument doc, string elementName, string descriptionName)
        {
            List<string> tempList = doc.Descendants(elementName).Descendants("Value").Select(e => e.Element(descriptionName).Value).ToList<string>();
            return tempList;
        }
        //gets a specified coin dice from treasures.xml
        public static Dice getCoin(XDocument doc, string elementName, string probabilityText, string coinType)
        {
            Dictionary<string, int> tempDic = new Dictionary<string, int>();
            if (elementName.Contains("Individual"))
            {
                var query = from currentObject in doc.Descendants(elementName).Elements("Value")
                            .First(t => t.Attribute("Text").Value == probabilityText).Descendants("Coins").Elements(coinType)
                            select new Dice()
                            {
                                objectType = coinType,
                                dieCount = int.Parse(currentObject.Attribute("DieCount").Value),
                                dieType = int.Parse(currentObject.Attribute("DieType").Value),
                                dieMultiplier = int.Parse(currentObject.Attribute("DieMultiplier").Value)
                            };
                return query.ToList<Dice>().First<Dice>();
            }
            else if (elementName.Contains("Hoard"))
            {
                var query = from currentObject in doc.Descendants(elementName).Descendants("Coins").Elements(coinType)
                            select new Dice()
                            {
                                objectType = coinType,
                                dieCount = int.Parse(currentObject.Attribute("DieCount").Value),
                                dieType = int.Parse(currentObject.Attribute("DieType").Value),
                                dieMultiplier = int.Parse(currentObject.Attribute("DieMultiplier").Value)
                            };
                return query.ToList<Dice>().First<Dice>();
            }
            return new Dice();
        }
        //gets a list of all coins (cp, sp, ep, gp, pp) dice from treasures.xml
        public static List<Dice> getCoins(XDocument doc, string elementName, string probabilityText)
        {
            List<Dice> coins = new List<Dice>();
            coins.Add(getCoin(doc, elementName, probabilityText, "CP"));
            coins.Add(getCoin(doc, elementName, probabilityText, "SP"));
            coins.Add(getCoin(doc, elementName, probabilityText, "EP"));
            coins.Add(getCoin(doc, elementName, probabilityText, "GP"));
            coins.Add(getCoin(doc, elementName, probabilityText, "PP"));
            return coins;
        }
        //gets a specified Treasure (Gems, Art, Magic) dice from treasures.xml
        public static List<Dice> getTreasure(XDocument doc, string elementName, string probabilityText, string treasureType)
        {
            var query = from currentObject in doc.Descendants(elementName).Elements("Value")
                        .First(t => t.Attribute("Text").Value == probabilityText).Descendants("Objects").Elements(treasureType)
                        select new Dice()
                        {
                            objectType = currentObject.Attribute("ObjectType").Value,
                            dieCount = int.Parse(currentObject.Attribute("DieCount").Value),
                            dieType = int.Parse(currentObject.Attribute("DieType").Value),
                            dieMultiplier = int.Parse(currentObject.Attribute("DieMultiplier").Value)
                        };

            return query.ToList<Dice>();
        }
    }
    public class RandomHelper
    { 
        public static Dictionary<string, int> RollRandomItem(List<Dice> collection)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            Random rollDie = new Random();

            foreach (var item in collection)
            {
                if (item.dieCount != 0)
                {
                    int totalCount = 0;
                    for (int i = 0; i < item.dieCount; i++)
                    {
                        totalCount += rollDie.Next(1, item.dieType + 1) * item.dieMultiplier;
                    }
                    output.Add(item.objectType, totalCount);
                }
            }
            return output;
        }
    }
}
