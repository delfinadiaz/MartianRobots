using System.Linq;

namespace MartianRobots.Domain.Entities.RobotOrientation
{
    public class West : Orientation
    {
        public override void MoveForward(Robot robot)
        {
            if (robot.CurrentPosition.CoordinateX - 1 < 0)
            {
                if (!robot.Mars.Scents.Any(s =>
                   s.CoordinateX == robot.CurrentPosition.CoordinateX &&
                   s.CoordinateY == robot.CurrentPosition.CoordinateY))
                {
                    robot.Mars.Scents.Add(CopyPosition(robot.CurrentPosition));
                    robot.IsLost = true;
                }
            }
            else
            {
                robot.CurrentPosition.CoordinateX--;
                robot.ExploredSurfaces.Add(new ExploredSurface
                {
                    Robot = robot,
                    Position = CopyPosition(robot.CurrentPosition)
                });
            }
        }

        public override void TurnLeft(Robot robot)
        {
            robot.Orientation = new South();
        }

        public override void TurnRight(Robot robot)
        {
            robot.Orientation = new North();
        }
    }
}
