using MartianRobots.Application.Commands.MarsCommands.FinalRobotsPositions;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Common;
using MartianRobots.Application.DTOs.Responses;
using MartianRobots.Domain.Common;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Entities.RobotOrientation;
using System.Collections.Generic;

namespace MartianRobots.UnitTests.Common
{
    public static class FinalRobotsPositionsTestsHelper
    {
        #region requests

        public static FinalRobotsPositionsRequest GetRequest()
        {
            return new FinalRobotsPositionsRequest()
            {
                Mars = new MarsDTO()
                {
                    MarsSize = new CoordinateDTO()
                    {
                        CoordinateX = 5,
                        CoordinateY = 3
                    },
                    MartianRobots = new List<RobotDTO>()
                    {
                        new RobotDTO()
                        {
                            CurrentPosition = new CoordinateDTO()
                            {
                                CoordinateX = 1,
                                CoordinateY = 1
                            },
                            Orientation = "E",
                            Instructions = "RFRFRFRF"
                        },
                        new RobotDTO()
                        {
                            CurrentPosition = new CoordinateDTO()
                            {
                                CoordinateX = 3,
                                CoordinateY = 2
                            },
                            Orientation = "N",
                            Instructions = "FRRFLLFFRRFLL"
                        },
                        new RobotDTO()
                        {
                            CurrentPosition = new CoordinateDTO()
                            {
                                CoordinateX = 0,
                                CoordinateY = 3
                            },
                            Orientation = "W",
                            Instructions = "LLFFFRFLFL"
                        }
                    }
                }
            };
        }

        public static FinalRobotsPositionsRequest GetInvalidRequest()
        {
            return new FinalRobotsPositionsRequest()
            {
                Mars = new MarsDTO()
                {
                    MarsSize = new CoordinateDTO()
                    {
                        CoordinateX = 51,
                        CoordinateY = 51
                    },
                    MartianRobots = new List<RobotDTO>()
                    {
                        new RobotDTO()
                        {
                            CurrentPosition = new CoordinateDTO()
                            {
                                CoordinateX = 51,
                                CoordinateY = 51
                            },
                            Orientation = "NN",
                            Instructions = "QWZ"
                        }
                    }
                }
            };
        }

        public static FinalRobotsPositionsRequest GetRobotDoesntDropAtSamePointRequest()
        {
            return new FinalRobotsPositionsRequest()
            {
                Mars = new MarsDTO()
                {
                    MarsSize = new CoordinateDTO()
                    {
                        CoordinateX = 5,
                        CoordinateY = 3
                    },
                    MartianRobots = new List<RobotDTO>()
                    {
                        new RobotDTO()
                        {
                            CurrentPosition = new CoordinateDTO()
                            {
                                CoordinateX = 3,
                                CoordinateY = 2
                            },
                            Orientation = "N",
                            Instructions = "FRRFLLFFRRFLL"
                        },
                        new RobotDTO()
                        {
                            CurrentPosition = new CoordinateDTO()
                            {
                                CoordinateX = 3,
                                CoordinateY = 2
                            },
                            Orientation = "N",
                            Instructions = "FRRFLLFFRRFLL"
                        }
                    }
                }
            };
        }

        #endregion

        #region responses

        public static Mars GetMarsResponse()
        {
            return new Mars()
            {
                Id = 1,
                MartianRobots = new List<Robot>()
                {
                    new Robot()
                    {
                        Id = 1,
                        CurrentPosition = new Coordinate()
                        {
                            CoordinateX = 1,
                            CoordinateY = 1
                        },
                        Orientation = new East(),
                        IsLost = false
                    },
                    new Robot()
                    {
                        Id = 2,
                        CurrentPosition = new Coordinate()
                        {
                            CoordinateX = 3,
                            CoordinateY = 3
                        },
                        Orientation = new North(),
                        IsLost = true
                    },
                    new Robot()
                    {
                        Id = 3,
                        CurrentPosition = new Coordinate()
                        {
                            CoordinateX = 4,
                            CoordinateY = 2
                        },
                        Orientation = new North(),
                        IsLost = false
                    }
                }
            };
        }

        public static MarsFinalRobotsPositionResponseDTO GetSuccesfulResponse()
        {
            return new MarsFinalRobotsPositionResponseDTO() {
                Id = 1,
                MartianRobots = new List<FinalRobotsPositionResponseDTO>()
                {
                    new FinalRobotsPositionResponseDTO()
                    {
                        Id = 1,
                        FinalPosition = new CoordinateDTO()
                        {
                            CoordinateX = 1,
                            CoordinateY = 1
                        },
                        FinalOrientation = 'E',
                        IsLost = string.Empty
                    },
                    new FinalRobotsPositionResponseDTO()
                    {
                        Id = 2,
                        FinalPosition = new CoordinateDTO()
                        {
                            CoordinateX = 3,
                            CoordinateY = 3
                        },
                        FinalOrientation = 'N',
                        IsLost = "LOST"
                    },
                    new FinalRobotsPositionResponseDTO()
                    {
                        Id = 3,
                        FinalPosition = new CoordinateDTO()
                        {
                            CoordinateX = 4,
                            CoordinateY = 2
                        },
                        FinalOrientation = 'N',
                        IsLost = string.Empty
                    }
                }
            };
        }

        public static Mars GetMarsRobotDoesntDropAtSamePointResponse()
        {
            return new Mars()
            {
                Id = 1,
                MartianRobots = new List<Robot>()
                {
                    new Robot()
                    {
                        Id = 1,
                        CurrentPosition = new Coordinate()
                        {
                            CoordinateX = 3,
                            CoordinateY = 3
                        },
                        Orientation = new North(),
                        IsLost = true
                    },
                    new Robot()
                    {
                        Id = 2,
                        CurrentPosition = new Coordinate()
                        {
                            CoordinateX = 3,
                            CoordinateY = 2
                        },
                        Orientation = new North(),
                        IsLost = false
                    }
                }
            };
        }

        public static MarsFinalRobotsPositionResponseDTO GetRobotDoesntDropAtSamePointResponse()
        {
            return new MarsFinalRobotsPositionResponseDTO()
            {
                Id = 1,
                MartianRobots = new List<FinalRobotsPositionResponseDTO>()
                {
                    new FinalRobotsPositionResponseDTO()
                    {
                        Id = 1,
                        FinalPosition = new CoordinateDTO()
                        {
                            CoordinateX = 3,
                            CoordinateY = 3
                        },
                        FinalOrientation = 'N',
                        IsLost = "LOST"
                    },
                    new FinalRobotsPositionResponseDTO()
                    {
                        Id = 2,
                        FinalPosition = new CoordinateDTO()
                        {
                            CoordinateX = 3,
                            CoordinateY = 2
                        },
                        FinalOrientation = 'N',
                        IsLost = string.Empty
                    }
                }
            };
        }

        #endregion
    }
}
