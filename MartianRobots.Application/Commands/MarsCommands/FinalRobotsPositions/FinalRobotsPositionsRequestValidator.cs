using FluentValidation;
using System.Text.RegularExpressions;

namespace MartianRobots.Application.Commands.MarsCommands.FinalRobotsPositions
{
    public class FinalRobotsPositionsRequestValidator : AbstractValidator<FinalRobotsPositionsRequest>
    {
        public FinalRobotsPositionsRequestValidator()
        {
            RuleFor(r => r.Mars).NotNull();
            When(r => r.Mars != null, () => {

                RuleFor(r => r.Mars.MarsSize.CoordinateX).InclusiveBetween(1, 50);
                RuleFor(r => r.Mars.MarsSize.CoordinateY).InclusiveBetween(1, 50);

                RuleForEach(r => r.Mars.MartianRobots)
                 .Must(robot => robot.CurrentPosition.CoordinateX <= 50 && robot.CurrentPosition.CoordinateY <= 50)
                    .WithMessage("The maximum value for any coordinate is 50.")

                 .Must(robot => robot.Instructions.Length <= 100 && Regex.IsMatch(robot.Instructions, @"^[F,L,R]+$"))
                    .WithMessage("An instruction is a string of the letters L, R, F and must be less than 100 characters in length.")

                 .Must(robot => robot.Orientation.Length == 1 && Regex.IsMatch(robot.Orientation, @"^[N,S,E,W]+$"))
                    .WithMessage("An orientation must be the character N, S, E or W for north, south, east, and west.");
            });

        }
    }
}
