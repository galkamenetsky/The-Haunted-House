The Haunted House

Main Scripts:
------------------------------------------------------------------
LevelData
- ScriptableObject, Every Instance is a level, holds all the information

------------------------------------------------------------------
LevelGeneratorMenu
- EditorWindow
- Use for create levels.

Flow:
- Go to scene "Level"
- Locate objects (player, coin, ghost(trap), door and a key) from folder "Assets/LevelGenerator/Generate Objects"
- Click on LevelGenerator tab on unityeditor.
- Type name for the level
- click GenerateLevel Button
- A scriptable object created on path "Assets/Levels"
- Drag the level into the object "DontDestroy" under the component "LevelSelector"
- Enjoy your level :).
-------------------------------------------------------------------
LevelController
- Read the level data for the current level
- Manage to create the level according to it
- Manage the integrate between the different kind of objects

------------------------------------------------------------------
Particles Manager
- Creates pool for each of the particles types
- When needed, move the particle to the position of the relevant object and play it.

------------------------------------------------------------------


Features
- Animations: Player, UI, Ghost, etc..
- Level editor for level creation.
- Nice timeline for start level and door open.
- UI Relative for screen size.
- Particle Systems can be modify easily


