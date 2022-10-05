using System.Linq;

namespace MartianRobots.Domain.Entities.RobotOrientation
{
    public class South : Orientation
    {
        public override void MoveForward(Robot robot)
        {
            if (robot.CurrentPosition.CoordinateY - 1 < 0)
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
                robot.CurrentPosition.CoordinateY--;
                robot.ExploredSurfaces.Add(new ExploredSurface
                {
                    Robot = robot,
                    Position = CopyPosition(robot.CurrentPosition)
                });
            }
        }

        public override void TurnLeft(Robot robot)
        {
            robot.Orientation = new East();
        }

        public override void TurnRight(Robot robot)
        {
            robot.Orientation = new West();
        }
    }
}
