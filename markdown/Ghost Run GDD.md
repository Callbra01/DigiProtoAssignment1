

# Ghost Run GDD: 

## Desired Game Mechanic: 

Ghost car visualization for lap times, that is determined to interrupt the player's new lap time, in order to "stay-alive". This will require the ghost car to attempt to sabotage a player’s run by driving into them when the player is close by.

## Objective Statement: 

How competitive can a singleplayer time trail game be, when your best time can actively sabotage the player?

## Detail design rationale: 

The experience that we are aiming for revolves around the player attempting to beat their best time in a lap, despite the odds created by their best times' attempt to sabotage the player. The experimental aspect of the design is in the rudimentary AI that controls the time visualization car; Putting a competitive spin on the classic time trial feature, that is generally considered a tool for the player to beat their personal best times.

## Team Roles
\- Dan: Unity working, Asset sourcing, level creation

\- Evan: Unity working, 3DS Max asset creation/source

\- Noah: Non-code writing, LFS and release management

\- Brandon: Code oversight/Management, commentator video

## Mechanic Details

Controls:  
 \- A, D : Steer left/right respectfully  
\- W, S : Throttle/Brake respectfully  
\- Spacebar : Handbrake

Technical Aspects:

1. When the game starts, the players position and rotation data is recorded to file during the lap.  
2. When the player completes a lap, the recorded data is played back onto the ghost car.  
3. Should the player be within proximity of the ghost car, the ghost car switches behavior and attempts to drive into the player.  
4. This repeats every lap.

## Target Audience

Game is intended for audiences that enjoy racing games that focus on time trial challenges. Specifically targeting the offline single player market.

## Creation Difficulties:

### Asset Difficulties:

1. Sedan car asset had texture troubles, not using that asset anymore in favor of a more low-poly asset  
2. Texture troubles turned out to be a result of the scene, therefore new scene has been made and track will be assembled from scratch

### Technical Difficulties:

1. Original plan to record player inputs and playback from file to move ghost car is too complex for the project. This has been resolved by storing position and rotation data for the player car in text files for ease of readability/modification.  
2. Data storage for 8 different variables (Pos x, y, z. Rot x, y, z, w. Frame number) made parsing from a single text file difficult. This was resolved by, disgustingly and regrettably, saving each variable to its own text file and doing a single parse for each.   
3. Modification of ghost car pathing was hard to visualize. This was amended by creating a path renderer for ease of development.   
4. Ghost car pathing created multiple issues, the largest of which is having the ghost car impact the player in a realistic way

## 

## Resource citations: 

Car controller script: PROMETEO: Car Controller

- [https://assetstore.unity.com/packages/tools/physics/prometeo-car-controller-209444?srsltid=AfmBOop2i1qq4QyisT\_kv1MgNkWP2bdFUx4WQ9FtDcIUyklaR-XDLBKn](https://assetstore.unity.com/packages/tools/physics/prometeo-car-controller-209444?srsltid=AfmBOop2i1qq4QyisT_kv1MgNkWP2bdFUx4WQ9FtDcIUyklaR-XDLBKn)

Track/Level creation assets: Mountain Race Tracks

- [https://assetstore.unity.com/packages/3d/environments/landscapes/mountain-race-tracks-110408](https://assetstore.unity.com/packages/3d/environments/landscapes/mountain-race-tracks-110408)

Player Car / Ghost Car Model: ARCADE: FREE Racing Car

- [https://assetstore.unity.com/packages/3d/vehicles/land/arcade-free-racing-car-161085](https://assetstore.unity.com/packages/3d/vehicles/land/arcade-free-racing-car-161085)

Sound files:

- [https://www.youtube.com/watch?v=QunyWALxgps\&ab\_channel=EverydayCinematicSounds](https://www.youtube.com/watch?v=QunyWALxgps&ab_channel=EverydayCinematicSounds)  
- [https://www.youtube.com/watch?v=\_eiC1lxdbaY\&ab\_channel=JacobBowerman](https://www.youtube.com/watch?v=_eiC1lxdbaY&ab_channel=JacobBowerman)  
- [https://www.youtube.com/watch?v=kuI-wbTE5PU\&ab\_channel=SoundLibrary](https://www.youtube.com/watch?v=kuI-wbTE5PU&ab_channel=SoundLibrary)


