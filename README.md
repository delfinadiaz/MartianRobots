# Martian Robots
The surface of Mars can be modelled by a rectangular grid around which robots are able to move according to instructions provided from Earth.
This Api determines each sequence of robot positions and reports the final position of the robot.

# Rest API

## Calculate final positions of given robots
### Request
POST /api/mars

Validations:
  
    The maximum value for any coordinate is 50.

    A robot instruction is a string of the letters "L", "R", and "F".

    All instruction strings will be less than 100 characters in length.

    An orientation is the character N, S, E or W for north, south, east, and west.
  
Example input: 

    {
      "mars": {
        "marsSize": {
          "coordinateX": 5,
          "coordinateY": 3
        },
        "martianRobots": [
          {
            "currentPosition": {
              "coordinateX": 1,
              "coordinateY": 1
            },
            "orientation": "E",
            "instructions": "RFRFRFRF"
          },
          {
            "currentPosition": {
              "coordinateX": 3,
              "coordinateY": 2
            },
            "orientation": "N",
            "instructions": "FRRFLLFFRRFLL"
          },
          {
            "currentPosition": {
              "coordinateX": 0,
              "coordinateY": 3
            },
            "orientation": "W",
            "instructions": "LLFFFRFLFL"
          }
        ]
      }
    }

## Get lost robots by a given mars id
### Request
GET /api/mars/{id}/lostrobots

Validations:
  
    Returns error not found if the given id doesn't exist in the database.

## Get explored surfaces by a given robot id
### Request
GET /api/robot/{id}/exploredsurfaces

Validations:
  
    Returns error not found if the given id doesn't exist in the database.




