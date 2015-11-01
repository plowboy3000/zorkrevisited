using System;
using System.Collections.Generic;

namespace NortheastAdventureGame
{
    public enum PlayerState
    {
        good,
        suspended,
        asleep
    }

    class NEPlayer
    {
        private string gamePlayerUsername;
        private string gamePlayerEmailAddress;
        private int gamePlayerPoints;
        private DateTime gamePlayerTimePlayed;
        private float gamePlayerCash;
        private List<NEGameObject> gameObjectCollection;
        private Enum playerState;
        
        public NEPlayer(string userName, string emailAddr, int startPoints, float startCash)
        {
            gamePlayerUsername = userName;
            gamePlayerEmailAddress = emailAddr;
            gamePlayerPoints = startPoints;
            gamePlayerTimePlayed = DateTime.Now;
            gamePlayerCash = startCash;
            gameObjectCollection = new List<NEGameObject>();
            playerState = PlayerState.good;
        } 

        public string getUsername()
        {
            return gamePlayerUsername;
        }

        public string getEmailAddress()
        {
            return gamePlayerEmailAddress;
        }

        public void incrementPlayerPoint(int plusOrMinus)
        {
            gamePlayerPoints += plusOrMinus;
        }

        public int getPlayerPoints()
        {
            return gamePlayerPoints;
        }

        public DateTime getTimeDatePlayerStartedGame()
        {
            return gamePlayerTimePlayed;
        }

        public TimeSpan getTimeSpanPlayerHasBeenPlaying()
        {
            return DateTime.Now.Subtract(gamePlayerTimePlayed);
        }

        public void incrementPlayerCash(float plusOrMinus)
        {
            gamePlayerCash = plusOrMinus;
        }

        public float getPlayerCash()
        {
            return gamePlayerCash;
        }

        public void addGameObject(NEGameObject gameObj)
        {
            gameObjectCollection.Add(gameObj);
        }

        public void dropGameObject(NEGameObject gameObj)
        {
            gameObjectCollection.Remove(gameObj);
        }

        public List<NEGameObject> getGameObjects()
        {
            return gameObjectCollection;
        }

        public NEGameObject getAGameObject(string gameObjName)
        {
            NEGameObject tempObj = null;
            foreach (NEGameObject obj in gameObjectCollection)
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
