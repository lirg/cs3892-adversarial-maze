#The Adversarial Maze

### Quick Links
* [Build](https://drive.google.com/drive/folders/1m8FLfdRvoRlUiGBp4xGgteITzYdHPfdW?usp=sharing)
* [Demo Video]()
## Summary
The Adversarial Maze serves as a mental endurance exercise for a psychology study. Based off of the Harry Potter hedge maze, the adversarial maze serves to bewilder and fluster players. The maze is set up with 5 yellow cubes - the collectibles - for the player to collect. There are landmarks scattered throughout the maze that serve as reference points for the player as they traverse the maze. The maze is split into three levels, each with increasing difficulty:

1. Static Maze (No moving objects)
2. Moving Walls (Walls move upon collectible pickup)
3. Moving Walls and Landmarks (Walls and landmarks move upon collectible pickup)

A timer and path tracer runs during the maze which will be logged after the maze is completed. The files can be used for data points.
## Technical Specs
* Unity Version: [2018.2.10f](https://unity3d.com/get-unity/download/archive)
* VR Hardware: Oculus Rift
* Assets:

## Scripts
#### OVRPlayerController
Attached to the VR player. It is a modification of the default OVRPlayerController script provided by Oculus. The end of the script has a custom OnTriggerEnter() function that is used to detect collectible pickups. Afterwards, other scripts are run such as logging, wall movement, and timer.
#### WallMover
Responsible for moving objects in the maze. Run by the OVRPlayerController when a pickup is collected.
#### PathTracing
Traces path of player as they traverse maze
#### SpherePlayerController
Alternative player of the maze in case the VR option is not available. Use only for testing purposes. Not all functionality is built into the SpherePlayerController
