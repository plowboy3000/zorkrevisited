namespace NortheastAdventureGame
{
    class NEGameObject
    {
        private string objName;
        private string objAboutMessage;
        private int objPoints;
        private float objCost;
        private int weight;
        private bool inventoryItem;

        //actions
        //private string takeObj;
        //private string dropObj;
        //private string examineObj;
        //private string inventoryObj;

        public NEGameObject(string name, string msg, int points, float cost, int objWeight, bool canPickUp)
        {
            objName = name;
            objAboutMessage = msg;
            objPoints = points;
            objCost = cost;
            weight = objWeight;
            inventoryItem = canPickUp;
        }

        public string getObjName()
        {
            return objName;
        }

        public string getAboutMessage()
        {
            return objAboutMessage;
        }

        public int getObjectPoints()
        {
            return objPoints;
        }

        public float getObjectCost()
        {
            return objCost;
        }

        //player actions that must be defined for each object: take drop examine inventory

    }
}
