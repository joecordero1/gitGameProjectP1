# gitGameProjectP1
#Aplicación de principios y arquitecturas de sistemas hipermedia
# JOE'S RECYCLING GAME
Link del video en Loom:
https://www.loom.com/share/b1e6ea3d6a9443faa4874845f7d37bc8?sid=37620d5c-7e74-4946-9a50-b19643d223fa

https://www.loom.com/share/2737385461134cd099ee9f044ce99ec9?sid=8876fa86-c954-4d81-bdf3-c508dfe67a41
## Game Overview
Desert Recycling Shooter is a first-person shooter game where you navigate through a desert landscape filled with dry trees, cacts, rocks, and various enemies. Your goal is to survive enemy attacks, collect trash from the enemies, and go to the next level, where you should take recyclable materials, and ultimately achieve a high recycling score.

## Features
- **Desert Environment**: A vast desert with an immersive environment that includes enemies and they trash after beign destroyed.
- **Enemies**: Aggressive enemies that will attack when you're in proximity and will chase if you try to escape.
- **Health System**: Start with 100 health points, with each enemy shot deducting 10 points.
- **Ammo Management**: Use ammo to take down enemies; each enemy requires 5 hits to be destroyed.
- **Recycling Mechanic**: Defeated enemies turn into Cola cans, symbolizing trash that can be collected.
- **Levels**: After collecting three cans, move to the next level, a trash-filled world where you could recycle items within a time limit.
- **Continuing Progress**: Recycling points are cumulative across attempts to encourage repeated play and strategy.
- **Scene Management**: Seamlessly switch between the main menu, sample scene, and recycling scene using colliders.
- **Score Saving**: Scores are saved in a JSON file and displayed on-screen.
- **First-Person Shooting**: Engage with enemies using raycast-based shooting mechanics, complete with visual and sound effects.
- **Health and Ammo Pickups**: Scattered throughout the world to replenish your supplies.
- **Enemy AI**: Smart enemies that detect your proximity and engage or pursue you.
- **Animations**: Smooth animations for recycling items like batteries and plastic bottles to make them more noticeable.
- **Sound**: Rich audio experience with background music, movement sounds, and victory sounds.
- **Progressive Destruction**: Enemies shrink in size with each hit, indicating damage.
- **Automatic Generation**: Enemies, health points, ammo, and recyclables are dynamically generated around the game world.

## Game Flow
1. **Main Menu**: Start your adventure and enter your name to track your score.
2. **Desert Scene**: Survive, shoot enemies, and collect cans to recycle.
3. **Recycling Scene**: Within a 20-second timer, grab as many recyclables as you can and deposit them.
4. **Repetition and Progress**: Return to the desert to continue collecting and recycling, aiming for 30 points.
5. **Victory**: Achieve the recycling goal, win the game, and save your score.

###--------------------------------------------
# Generating the README.md content for the programming features requested by the user.

# Programming Features

## Ammo Management
- Players start with a limited supply of ammo.
- Each shot fired depletes the ammo count.
- Ammo pickups are scattered throughout the level to resupply.
- Script `BulletScript.cs` handles the bullet behavior including instantiation and collision detection.

## Levels
- The game includes multiple levels with unique challenges and environments.
- Transition between levels is managed by `ScenesManagerScript.cs`, which handles scene loading based on player actions and progression.

## Continuing Progress
- Player progress, including collected recyclables and score, persists between level changes.
- `PlayerData.cs` keeps track of points and is not reset until the game is over, ensuring cumulative progress.

## Enemy AI
- Enemies detect player's proximity and engage in pursuit if the player tries to escape.
- The `enemyFollow.cs` script handles the AI behavior for seeking and attacking the player.

## Score Saving
- Scores are saved to a JSON file, `playerlist.json`, allowing players to keep a record of their achievements.
- `JsonWritter.cs` is responsible for writing the player's score to the file after each level completion.

## Health and Ammo Pickups
- Health and ammo pickups are available to replenish player resources.
- `HealthScript.cs` and `AmmoBoxScript.cs` control the behavior and effects of these pickups when collected.

## Animations
- Animated objects such as recyclable items and enemy reactions enhance the game's visual feedback.
- Scripts like `RecycledObjScript.cs` manage the animations and ensure they are triggered by in-game events.

## Sound
- A rich sound design includes background music, shooting effects, and audio cues for player actions and environment interaction.
- Managed within Unity's audio system, and scripts like `TrashScript.cs` control when to play certain sound effects.

## Progressive Destruction
- Enemies react to being hit with visual cues such as scaling down, indicating damage taken.
- The `Shooted.cs` script modifies enemy appearance progressively as they take damage with the ReduceScale() method, 

## Automatic Generation
- The game world dynamically generates enemies and pickups to maintain a consistent challenge and resource availability.
- `Generator.cs` and `R_Generator.cs` scripts manage the spawning of these game objects throughout the level.

Each feature is carefully crafted to create an engaging and dynamic gameplay experience. Scripts interact with Unity's physics, audio, and animation systems to bring the desert wasteland and its challenges to life

