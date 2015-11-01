using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortheastAdventureGame
{
    class NEActionVocabulary
    {
        private List<string> actionVocabulary;

        public NEActionVocabulary()
        {
            actionVocabulary = new List<string>();
            createVocabulary();
        }

        private void createVocabulary()
        {
            actionVocabulary.Add("Take");
            actionVocabulary.Add("Drop");
            actionVocabulary.Add("Examine");
            actionVocabulary.Add("Inventory");
        }

        public bool isAction(string action)
        {
            bool tempbool = false;
            foreach (string str in actionVocabulary)
            {
                if (str.ToUpper() == action.ToUpper())
                {
                    tempbool = true;
                }
            }
            return tempbool;
        }
    }
}
