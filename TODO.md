# TODO Document
In this document I will be adding whatever I know I have to do, and I will try to categorize it.

#### Programming Quality
- [ ] GameController Singleton
- [ ] LevelController Singleton per level
- [ ] Normal ground Prefab **Has to be improved now**
- [ ] Sonarqube integration for better code quality

#### Gameplay Quality
- [x] Create a way for platforms not to activate if the character is close to hitting them, but allow to deactivate
- [ ] Menu / UI

#### Movement System
- [x] Jump
- [x] Horizontal Movement
- [x] Ground check
- [ ] Check why the RigidBody2D feels so slippery

#### Input Recording
- [x] Jump
- [x] Horizontal axis
- [x] Change input recording to ~~structs or~~ classes instead of strings

#### Input Recreating
- [x] Jump
- [x] Horizontal Movement https://docs.microsoft.com/en-us/dotnet/api/system.io.file?redirectedfrom=MSDN&view=netframework-4.7.2

#### Gameplay Mechanics
- [ ] Spawning
- [ ] Despawning / Getting to the door
- [x] Activate element
- [x] Deactivate element
- [x] Require two buttons to be pressed when activating (i.e. W for selecting the platform and SPACE for activating it) https://answers.unity.com/questions/553618/how-can-i-use-multiple-getbuttondown-keys-simultan.html

#### Gameplay Elements
- [ ] Enter gates
- [ ] Exit gates
- [x] Platform that activates and deactivates
- [ ] Platform that moves in a certain pattern (See native Unity behaviour for this) when activated
- [ ] Platform that moves one direction when pressing a button and moves the other when pressing other

#### Levels
- [ ] Automatic win level
- [ ] Need to activate a simple platform
- [ ] Need to activate two platforms, one after the other
- [ ] Need to activate one platform and deactivate another


#### Backlog / Ideas
- [ ] Characters with different colors
- [ ] Elements of different colors (specific doors, platforms and so on)
- [ ] Maximum number of elements active ~~or of the same color~~ at the same time?
- [ ] **Levels with many characters (Lemmings' style)**
- [ ] Difficult combinations of buttons to press (Twister-style)?
- [ ] Elements that activate and deactivate any time any other thing is activated or deactivated
