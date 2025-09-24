
# Game Mechanic Ideation
### Surfing Game
> 1. Players balance and preform tricks with various different inputs
### Gravity Flipping Game
> 1. Interactable objects allow for gravity manipulation
> 2. Segments of level requiring gravity to be changed for progression
### Survival Carting Game
> 1. Rudimentary AI that can respond to players actions, and modify their default inputs from the players previous laps
> 2. Ghost racing your best time, with the ghost being able to directly influence the player
> 3. As laps progress, the ghost racer can 
> #### Objective Statement: How competitive can a racing game, when playing against yourself
> 
### Roller Skating Game
> Trigger inputs act as independent controllers for the players movement

# Team Roles
> Dan: Unity working, 
> Evan: Unity working, 3DS Max asset creation/source
> Noah: Non-code writing, LFS and release managment
> Brandon: Code oversight/Management, commentator video

### First Meeting Notes
> 1. Dont make all the assets from scratch
> 2. Source assets/ demos
> 3. Focus on the Objective statement
> 4. Someone needs to be responsible for gtls and gitrelease
> 5. Designer commentator video, 5 minutes max
> 6. Keep markdown stuff in the root folder

# Difficulties 

### Asset Difficulties
1. Sedan car asset had texture troubles, not using that asset anymore in favour of a more low-poly asset
2. Texture troubles turned out to be a result of the scene, therefore new scene has been made and track will  
	be assembled from scratch

### Technical Difficulties
1. Original plan to record player inputs and play back from file to move ghost car is too complex for the project. This has been resolved by storing position and rotation data for the player car in text files for ease of readability/modification
2. Data storage for 8 different variables (Pos x, y, z. Rot x, y, z, w. Frame number) made parsing from a single text file difficult. This was resolved by, disgustingly and regrettably, saving each variable to its own text file and doing a single parse for each.
3. Modification of ghost car pathing was hard to visualize. This was ammended by creating a path renderer for ease of development.


# Final Documentation Goals

1. **Define the desired game mechanic or feature**.
	> Ghost car visualization for lap times, that is determined to interrupt the players new lap time, in order to "stay-alive".
2.  **Outline an objective statement for the design**
	> How competitive can a singleplayer time trail game be, when your best time can actively sabotage the player?
3.  **Detail design rationale**.
	> The experience that we are aiming for revolves around the player attempting to beat their best time in a lap, despite the odds created by their best times' attempt to sabotage the player. The experimental aspect of the design is in the rudimentary AI that controls the time visualization car; Putting a competitive spin on the classic time trial feature, that is generally considered a tool for the player to beat their personal best times.
5.  **Cite all resources, tangible, informative, and transformative**
