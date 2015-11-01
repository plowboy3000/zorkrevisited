using System.Collections.Generic;

namespace NortheastAdventureGame
{
    class NEMapPoint
    {
        private int pointID;
        public int PointID
        {
            get
            {
                return pointID;
            }
            set
            {
                pointID = value;
            }
        }

        private int posX;
        public int PosX
        {
            get
            {
                return posX;
            }
        }

        private int posY;
        public int PosY
        {
            get
            {
                return posY;
            }            
        }

        private List<NEMapPointConnector> pointConnections;
        private List<NEGameObject> gameObjectCollection;

        private string pointMessage;
        public void setPointMessage(string msg)
        {
            pointMessage = msg;
        }
        public string getPointMessage()
        {
            return pointMessage;
        }

        public NEMapPoint(int pntID, int X, int Y, string msg)
        {
            pointID = pntID;
            posX = X;
            posY = Y;
            pointMessage = msg;
            pointConnections = new List<NEMapPointConnector>();
            gameObjectCollection = new List<NEGameObject>();
        }
        public void addPointConnection(NEMapPointConnector connector)
        {
            pointConnections.Add(connector);
        }
        public List<NEMapPointConnector> getPointConnections()
        {
            return pointConnections;
        }

        public void addGameObject(NEGameObject gameObj)
        {
            gameObjectCollection.Add(gameObj);
        }
        public void dropGameObject(NEGameObject gameObj)
        {
            gameObjectCollection.Remove(gameObj);
        }

        public List<NEGameObject> getGamePointObjects()
        {
            return gameObjectCollection;
        }
        
        public bool isValidObject(string objectName)
        {
            bool foundObj = false;
            foreach (NEGameObject obj in gameObjectCollection)
            {
                if (obj.getObjName().ToUpper() == objectName.ToUpper())
                {
                    foundObj = true;
                }
            }
            return foundObj;
        }       

        public NEGameObject getAGameObject(string gameObjName)
        {
            NEGameObject tempObj = null;
            foreach(NEGameObject obj in gameObjectCollection)
            {
                if (obj.getObjName().ToUpper() == gameObjName.ToUpper())
                {
                    tempObj = obj;
                }
            }
            return tempObj;
        }
    }
}
