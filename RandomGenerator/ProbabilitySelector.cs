using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGenerator
{
    class ProbabilitySelector
    {
        Dictionary<string, int> probabilityDictionary;
        private Random rand = new Random();

        //parses two lists to a dictionary
        public ProbabilitySelector(List<string> result, List<int> weight)
        {
            if (result != null && weight != null && result.Count == weight.Count)
                //Zip puts two lists together in-order
                probabilityDictionary = result.Zip(weight, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
            else
                throw new Exception("Result and Probability are not of equal length or are null");
        }

        //Randomly select a result from the classes dictionary
        public string rouletteSelect()
        {
            // calculate the total weight
            int weightSum = 0;
            foreach (KeyValuePair<string, int> keyValue in probabilityDictionary)
            {
                weightSum += keyValue.Value;
            }
            // get a random value (maxValue is non inclusive, hence the +1)
            int value = rand.Next(weightSum+1);
            // locate the random value based on the weights
            for (int i = 0; i < probabilityDictionary.Count; i++)
            {
                value -= probabilityDictionary.ElementAt(i).Value;
                if (value <= 0) return probabilityDictionary.ElementAt(i).Key;
            }
            // when rounding errors occur, we return the last item's index 
            return probabilityDictionary.Last().Key;
        }
    }
}
