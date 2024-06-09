# game-dev-project-2d-isometric-rpg

### Author
- **Author:** Andrew Palamie Chanthakoun
- **Year and Semester:** Spring, 2nd year, 2024
- **Project Type:** Solo Project

### Tools and Artifacts

- Unity game engine.
- C# and JavaScript programming languages.
- INK (narrative scripting language).
- JSON.
- GitHub for version control.


## Project Scope

The final project will feature:

- Engaging gameplay mechanics including exploration, combat, and questing.
- Basic storytelling and world-building elements.
- Character health and inventory management.
- Isometric environment with 2D art.
- Enemy and player combat with AI.
- Save/Load system.
- 
### Planned Features

- User/player character movement (WASD controls).
- Combat controls via mouse directions and clicks.
- UI design for health and HUD.
- 2D animations.
- Enemy AI pathfinding/combat.
- Multiple game levels/regions.
- Weapon selection/resource management.
- Save/load system for players.
- NPC dialogue system.
- Player health management.

### If time permits, I would like to implement:

- Dynamic events and random encounters.
- Skill and leveling system for players.
- More advanced AI behaviors for enemies and NPCs.
- Interactive environment and NPCs.
- 
### Deployment
The project will be deployed on PC and will be compatible with Windows and other PC operating systems (mac, linux).

## Project Updates

**Date:** April 27, 2024

**Features Added/Updated Since Last Update:**
- Implemented player movement along with combat
- Added basic enemy ability to deal damage to player along with attack animations
- Integrated health bars for player to visualize health status.
- implemented a starting main menu that for now allows starting the game into the test level and the ability to quit the game.

**Issues Encountered:**
- Encountered an issue with animations with the timing of triggers and smoothness of animations to work when needed when used in scripts(WORK IN PROGRESS)
- Encountered a bug when enemy triggered it's "hurt" animation the enemy would freeze and no longer work (FIXED)
- Faced challenges with implementing code for the enemy to do damage to the player (FIXED)
- Encountered an issue with the unity engine throwing errors due to certain scripts even when the scripts were not being used (FIXED)

**Lessons Learned:**
- Importance of iterative development: Breaking down tasks into smaller iterations allows for more manageable progress and easier troubleshooting of issues.
- Prioritizing performance optimization: As the project scales, optimizing performance becomes increasingly crucial to ensure a smooth gameplay experience across different platforms.
- Importance of keeping track of code: As more scripts and codes are added it increasingly becomes more overwhealming and keeping track with note's and code comments becomes increasingly important.


https://github.com/chanthakoun2002/game-dev-project-2d-isometric-rpg/assets/121994183/a785f6bc-438a-4807-a80f-e60157f9c1c8

**Date:** May 12, 2024

**Features Added/Updated Since Last Update:**
- Implemented enemy pathfinding to track and follow the player
- added multiple scenes which the player can travel between
- allow the player to have data (health data) be kept/saved between scenes but reset upon new game start

**Issues Encountered:**
- Still encountering issues with the smoothness of animations and how they are being triggered, especially animations used by enemies (WIP)
- currently encountering a bug on certain scenes where an enemy will not properly pathfinder but will exit the nav mesh area and will attack but not track the player (FIXED)
- encountered an issue where the player loaded in a scene the player character would multiply (FIXED)

**Lessons Learned:**
- Understanding the intricacies of scene management in Unity, including proper initialization and cleanup procedures to prevent unintended behavior
- Importance of thorough testing and debugging to identify and resolve issues promptly
- Utilizing Unity's NavMesh system effectively for AI pathfinding, including fine-tuning parameters and optimizing NavMesh baking settings
  
https://github.com/chanthakoun2002/game-dev-project-2d-isometric-rpg/assets/121994183/60d10300-ee53-4618-8ed6-dcefabf611e0


**Date:** May 26, 2024

**Features Added/Updated Since Last Update:**
- added inventory system for the player to pick up items and store them in their inventory
- added in health potion item that players can pick up and store in their inventory and replenish health
- improved loading for scenes so when a player loads from certain scenes they will load in specific locations depending on the last scene
- added in a kill counter to track how many kills the player has
- improved enemy so now when they die their sprite disappears after a little time has passed
- added in a new scene and improvements to other scenes in the game including expanded maps and better looks to the environment
- added in a pause button to open a menu to allow for resuming game or quite to menu and buttons for saving and loading games (button for save and load not used currently)

**Issues Encountered:**
- there is an issue with only scene index 1 with spawn locations not working correctly and the player always spawns at default (FIXED)
- issue with how the main menu is currently working and a new game is not wiping the last game data otherwise game will crash (a new issue that did not happen on the later versions) (FIXED)
- encountered an issue with inventory not saving between scenes (FIXED)
- A small bug found that causes some potions to not able to be picked up by the player, which only happens randomly to some potions after the player has used all inventory space and then used all potions in inventory (FIXED)

**Lessons Learned:**
- better understanding of how the unity engine works especially how playerPrefs work and how saving and loading data works with unity
- understanding of how serializable objects work and how to implement them in unity

**Date:** June 9, 2024

**Features Added/Updated Since Last Update:**
- added in save load functionality so now players/users are able to open a load/save menu from the main/pause menu to save or load from 3 slots that will save the current game data into JSON file and load their data when they want.
- added a single interactable NPC that the player can "talk" to at the first level of the game
- added in music for each scene so now with each scene entered player can hear music
- added in an additional scene
- balanced out scenes by adjusting the amount of enemies and potions so earlier scenes are easier while later scenes are harder
- added in a spawn manager for better spawns and no more issues with players not spawning in locations
- added in a panel for the load with three slots to allow for a player to save, load, and delete their save


**Issues Encountered:**
- issue with implementing the NPC dialogue and dialogue manager not generating or finding the text it needed to generate (FIXED)
- bug with button not opening up panel for save/load slots from the main menu (FIXED)
- ran into an issue with inventory not being loaded in correctly from the JSON, issue relating to the order in which certain scripts are run at the start (FIXED)

**Lessons Learned:**
- understanding of how to write to a JSON file and load from one and save the data I need and how to apply that data back into my game/code and overall understanding of how persistent data works
  
