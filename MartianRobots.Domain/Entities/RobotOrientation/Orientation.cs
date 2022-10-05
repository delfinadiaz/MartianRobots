using MartianRobots.Domain.Common;

namespace MartianRobots.Domain.Entities.RobotOrientation
{
    public abstract class Orientation
    {
        public abstract void MoveForward(Robot robot);
        public abstract void TurnRight(Robot robot);
        public abstract void TurnLeft(Robot robot);

        public Coordinate CopyPosition(Coordinate coordinateToCopy)
        {
            return new Coordinate
            {
                CoordinateX = coordinateToCopy.CoordinateX,
                CoordinateY = coordinateToCopy.CoordinateY
            };
        }
        
    }
}
