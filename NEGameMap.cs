using System.Collections.Generic;

namespace NortheastAdventureGame
{
    class NEGameMap
    {
        private List<NEMapPoint> mapPoints;
        private NEMapPoint mapPointer;
        private NEPlayer gamePlayer;
        
        public NEGameMap()
        {
            mapPoints = new List<NEMapPoint>();
            createNewMap();
            mapPointer = mapPoints[0]; //starting location
            gamePlayer = new NEPlayer("Dave", "dlblair@northeaststate.edu", 0, 12500);
        }

        public List<NEGameObject> getPlayerObjects()
        {
            return gamePlayer.getGameObjects();
        }

        public void dropPlayerGameObject(string gameObjName)
        {
            NEGameObject gameObj = gamePlayer.getAGameObject(gameObjName);
            gamePlayer.dropGameObject(gameObj);
            mapPointer.addGameObject(gameObj);
        }
        
        public void addPlayerGameObject(string gameObjName)
        {
            NEGameObject gameObj = mapPointer.getAGameObject(gameObjName);
            mapPointer.dropGameObject(gameObj);
            gamePlayer.addGameObject(gameObj);
        }

        public List<NEGameObject> getPlayerGameInventory()
        {
            return gamePlayer.getGameObjects();
        }

        public string getPlayerName()
        {
            return gamePlayer.getUsername();
        }

        public string getPlayerCash()
        {
            return gamePlayer.getPlayerCash().ToString("C");
        }

        public string getPlayerPoints()
        {
            return gamePlayer.getPlayerPoints().ToString();
        }

        public string getCurrentLocationMessage()
        {
            string pointMsg = mapPointer.getPointMessage();
            return pointMsg;
        }

        public List<string> getDirections()
        {
            List<string> connections = new List<string>();
            int numOfPaths = mapPointer.getPointConnections().Count;
            foreach (NEMapPointConnector conn in mapPointer.getPointConnections())
            {
                connections.Add(conn.getDirection());                
            }
            return connections;
        }

        public int getValidDirectionPointID(string direction)
        {
            int nextNextMapPoint = -1;
            foreach (NEMapPointConnector conn in mapPointer.getPointConnections())
            {
                if (conn.getDirection() == direction)
                {
                    nextNextMapPoint = conn.getDestinationPoint().PointID;
                }
                
            }
            return nextNextMapPoint;
        }

        public List<NEGameObject> getCurrentPointGameObjects()
        {
            return mapPointer.getGamePointObjects();
        }

        public void moveToNewPoint(int pnt)
        {
            mapPointer = mapPoints[pnt];
        }

        public NEMapPoint getCurrentPoint()
        {
            return mapPointer;
        }

        /// <summary>
        /// Creating a map could be reading points from a config file
        /// so the maps could be changed easily without recompiling 
        /// the application
        /// </summary>
        private void createNewMap()
        {
            //add map points
            NEMapPoint pointA = new NEMapPoint(0, 0, 0, "You are deep in deep dark and scary woods");
            NEMapPoint pointB = new NEMapPoint(1, 1, 1, "You are in a very hot dry desert");
            NEMapPoint pointC = new NEMapPoint(2, 2, 0, "You are on top of old Smokey, all covered in snow");
            NEMapPoint pointD = new NEMapPoint(3, 2, 1, "You are on a large riverboat steaming down the mighty Mississippi");
            
            //create map connections
            NEMapPointConnector connectorAB = new NEMapPointConnector(pointA, pointB);

            NEMapPointConnector connectorBC = new NEMapPointConnector(pointB, pointC);
            NEMapPointConnector connectorBD = new NEMapPointConnector(pointB, pointD);
            NEMapPointConnector connectorBA = new NEMapPointConnector(pointB, pointA);

            NEMapPointConnector connectorDB = new NEMapPointConnector(pointD, pointB);

            NEMapPointConnector connectorCB = new NEMapPointConnector(pointC, pointB);

            NEMapPointConnector connectorCD = new NEMapPointConnector(pointC, pointD);
            NEMapPointConnector connectorDC = new NEMapPointConnector(pointD, pointC);

            //add connections between each map point
            pointA.addPointConnection(connectorAB);

            pointB.addPointConnection(connectorBC);
            pointB.addPointConnection(connectorBD);
            pointB.addPointConnection(connectorBA);

            pointD.addPointConnection(connectorDB);

            pointC.addPointConnection(connectorCB);

            pointC.addPointConnection(connectorCD);
            pointD.addPointConnection(connectorDC);

            //create game objects that go on the map
            NEGameObject gameObjMap = new NEGameObject("Galaxy Map", "This map will show you the way!", 100, 50, 1, true);
            NEGameObject gameObjScrewdriver = new NEGameObject("Atomic Screwdriver", "Use this to open a trap door!", 150, 70, 2, true);
            NEGameObject gameObjMagicHat = new NEGameObject("Magic Hat", "Say magic words when wearing this hat!", 200, 120, 3, true);
            NEGameObject gameObjFountainPen = new NEGameObject("Fountain Pen", "Write a message!", 250, 135, 4, true);

            pointB.addGameObject(gameObjMap);
            pointB.addGameObject(gameObjScrewdriver);
            pointD.addGameObject(gameObjMagicHat);
            pointC.addGameObject(gameObjFountainPen);

            //finally add all info to map points list
            mapPoints.Add(pointA);
            mapPoints.Add(pointB);
            mapPoints.Add(pointC);
            mapPoints.Add(pointD);
        }//end createNewMap function
        
    }
}
