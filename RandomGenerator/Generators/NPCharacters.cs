using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RandomGenerator
{
    class NPCharacters
    {
        private XDocument reader = XDocument.Load("../../XML/NPCs.xml");

        private ProbabilitySelector appearanceSelector;
        private ProbabilitySelector abilitySelector;
        private ProbabilitySelector talentSelector;
        private ProbabilitySelector mannerismSelector;
        private ProbabilitySelector interactionSelector;
        private ProbabilitySelector idealSelector;
        private ProbabilitySelector bondSelector;
        private ProbabilitySelector flawSelector;
        private static List<string> abilityText;
        private static List<string> highAbilityDesc;
        private static List<string> lowAbilityDesc;

        //Populates our probability selectors and ability descriptions
        public NPCharacters()
        {
            appearanceSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Appearances"), XDocumentHelper.getProbability(reader, "Appearances"));
            abilityText = XDocumentHelper.getText(reader, "Abilities");
            abilitySelector = new ProbabilitySelector(abilityText, XDocumentHelper.getProbability(reader, "Abilities"));
            talentSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Talents"), XDocumentHelper.getProbability(reader, "Talents"));
            mannerismSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Mannerisims"), XDocumentHelper.getProbability(reader, "Mannerisims"));
            interactionSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Interactions"), XDocumentHelper.getProbability(reader, "Interactions"));
            idealSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Ideals"), XDocumentHelper.getProbability(reader, "Ideals"));
            bondSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Bonds"), XDocumentHelper.getProbability(reader, "Bonds"));
            flawSelector = new ProbabilitySelector(XDocumentHelper.getText(reader, "Flaws"), XDocumentHelper.getProbability(reader, "Flaws"));
            highAbilityDesc = XDocumentHelper.getDescription(reader, "Abilities", "HighDescription");
            lowAbilityDesc = XDocumentHelper.getDescription(reader, "Abilities", "LowDescription");
        }
        //returns a random NPC
        public string randomResult()
        {
            StringBuilder outputString = new StringBuilder("Appearance: ").Append(appearanceSelector.rouletteSelect()).AppendLine();

            //Ensures the Low Ability is never the same as the high ability, also maps ability description to the ability chosen based on index position
            string highAbility = abilitySelector.rouletteSelect();
            outputString.Append("High Ability: ").Append(highAbility).Append("-").Append(highAbilityDesc[abilityText.IndexOf(highAbility)]).AppendLine();
            string lowAbility;
            do
            {
                lowAbility = abilitySelector.rouletteSelect();
            } while (highAbility.Equals(lowAbility));
            outputString.Append("Low Ability: ").Append(lowAbility).Append("-").Append(lowAbilityDesc[abilityText.IndexOf(lowAbility)]).AppendLine();

            outputString.Append("Talent: ").Append(talentSelector.rouletteSelect()).AppendLine();
            outputString.Append("Mannerism: ").Append(mannerismSelector.rouletteSelect()).AppendLine();
            outputString.Append("Interaction with Others: ").Append(interactionSelector.rouletteSelect()).AppendLine();
            outputString.Append("Ideal: ").Append(idealSelector.rouletteSelect()).AppendLine();

            //Calculates bonds (one or two) and ensures if there are two bonds, that they are different
            string bond = bondSelector.rouletteSelect();
            if (bond == "Two Bonds")
            {
                while (bond.Equals("Two Bonds"))
                {
                    bond = bondSelector.rouletteSelect();
                }
                outputString.Append("Bond: ").Append(bond).Append(" and ");
                string secondBond;
                do
                {
                    secondBond = bondSelector.rouletteSelect();
                } while (bond.Equals(secondBond) || secondBond.Equals("Two Bonds"));
                outputString.Append(secondBond).AppendLine();
            }
            else
                outputString.Append("Bond: ").Append(bond).AppendLine();

            outputString.Append("Flaw: ").Append(flawSelector.rouletteSelect());

            return outputString.ToString();
        }
    }
}
