using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortheastAdventureGame
{
    class NEMapPointConnector
    {
        private NEMapPoint sourcePoint;
        private NEMapPoint destinationPoint;
        private string direction;
           
        public NEMapPointConnector(NEMapPoint FromPoint, NEMapPoint ToPoint)
        {
            sourcePoint = FromPoint;
            destinationPoint = ToPoint;
            direction = calculateDirection();
        }

        private string calculateDirection()
        {
            //return calculated string direction
            string dir = "";
            int calcX = sourcePoint.PosX - destinationPoint.PosX;
            int calcY = sourcePoint.PosY - destinationPoint.PosY;
            if (calcX >= 1 && calcY >= 1)
            {
                dir = "Southwest";
            } else if (calcX >= 1 && calcY == 0)
            {
                dir = "West";
            } else if (calcX >= 1 && calcY <= -1)
            {
                dir = "Northwest";
            } else if (calcX == 0 && calcY <= -1)
            {
                dir = "North";
            } else if (calcX <= -1 && calcY <= -1)
            {
                dir = "Northeast";
            } else if (calcX <= -1 && calcY == 0)
            {
                dir = "East";
            } else if (calcX <= -1 && calcY >= 1)
            {
                dir = "Southeast";
            } else if (calcX == 0 && calcY >= 1)
            {
                dir = "South";
            }

            return dir;
        }

        public string getDirection()
        {
            return direction;
        }

        public NEMapPoint getDestinationPoint()
        {
            return destinationPoint;
        }
    }
}
