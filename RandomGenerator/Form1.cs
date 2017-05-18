using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomGenerator
{
    public partial class Form1 : Form
    {
        //TODO: Disability tags, text box read only?, Room description, npc description
        public Form1()
        {
            InitializeComponent();
        }

        TavernName tavern = new TavernName();
        DungeonAdventure dungeon = new DungeonAdventure();
        SettlementBuilder settlement = new SettlementBuilder();
        BuildingType building = new BuildingType();
        NPCharacters npc = new NPCharacters();
        TreasureGenerator treasure = new TreasureGenerator();
        
        private void comboBoxGenerators_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxResult.Clear();
            if (comboBoxGenerators.SelectedItem.ToString().Equals("Treasure")) 
                groupBoxTreasure.Visible = true;
            else
                groupBoxTreasure.Visible = false;
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();

            switch (comboBoxGenerators.SelectedItem.ToString())
            {
                case "Tavern Name":
                    textBoxResult.AppendText(tavern.randomResult());
                    break;
                case "Dungeon":
                    textBoxResult.AppendText(dungeon.randomResult());
                    break;
                case "Settlement":
                    textBoxResult.AppendText(settlement.randomResult());
                    break;
                case "Building":
                    textBoxResult.AppendText(building.randomResult());
                    break;
                case "NPC":
                    textBoxResult.AppendText(npc.randomResult());
                    break;
                case "Treasure":
                    string type = "";
                    if (radioButtonTreasureIndividual.Checked)
                        type = radioButtonTreasureIndividual.Text;
                    else
                        type = radioButtonTreasureHoard.Text;
                    textBoxResult.AppendText(treasure.randomResult(type, comboBoxTreasureLevelRange.SelectedItem.ToString()));
                    break;
            }
        }
    }
}
