using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RandomGenerator
{
    class BuildingType
    {
        private XDocument reader = XDocument.Load("../../XML/Buildings.xml");

        private ProbabilitySelector buildingSelector;
        private ProbabilitySelector residenceSelector;
        private ProbabilitySelector religiousSelector;
        private ProbabilitySelector tavernSelector;
        private ProbabilitySelector warehouseSelector;
        private ProbabilitySelector shopSelector;

        //Populates our probability selectors and purpose descriptions
        public BuildingType()
        {
            buildingSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "BuildingType"), XDocumentHelper.getProbability(reader, "BuildingType"));
            residenceSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Residence"), XDocumentHelper.getProbability(reader, "Residence"));
            religiousSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "ReligiousBuilding"), XDocumentHelper.getProbability(reader, "ReligiousBuilding"));
            tavernSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Tavern"), XDocumentHelper.getProbability(reader, "Tavern"));
            warehouseSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Warehouse"), XDocumentHelper.getProbability(reader, "Warehouse"));
            shopSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Shop"), XDocumentHelper.getProbability(reader, "Shop"));
        }
        //returns a random building
        public string randomResult()
        {
            string buildingType = buildingSelector.rouletteSelect();
            StringBuilder outputString = new StringBuilder(buildingType).Append(": ");
            
            //specifics returned for each building
            switch (buildingSelector.rouletteSelect())
            {
                case "Residence":
                    outputString.Append(residenceSelector.rouletteSelect());
                    break;
                case "Religious":
                    outputString.Append(religiousSelector.rouletteSelect());
                    break;
                case "Tavern":
                    TavernName tavernName = new TavernName();
                    outputString.Append(tavernSelector.rouletteSelect()).Append(", ").Append(tavernName.randomResult()); //also get tavern name
                    break;
                case "Warehouse":
                    outputString.Append(warehouseSelector.rouletteSelect());
                    break;
                case "Shop":
                    outputString.Append(shopSelector.rouletteSelect());
                    break;
            }
            return outputString.ToString();
        }
    }
}
