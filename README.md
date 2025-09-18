# 🕹️ EsCave – 2D Platformer  

The **EsCave project** is a 2D Unity platformer game where the player must navigate through a cave, collect a key, and reach the exit door while avoiding deadly traps and enemies. The game is divided into three levels with increasing difficulty: **Easy, Intermediate, and Hard**.  

---

## 📋 Project Overview  
The objective of the game is to challenge the player’s agility and decision-making through progressive levels:  

- Explore a rocky cave environment with traps and enemies.  
- Collect the **key** to unlock the exit door.  
- Reach the door to complete the level and display a victory screen.  
- Manage death mechanics with respawn and replay options.  

---

## 🛠️ Technologies Used  
- **Game Engine**: Unity  
- **Language**: C# (Unity Scripts)  
- **Tools**: Unity Animator, UI Manager, Scene Management  

---

## 🧩 Project Structure  

### 🎮 Player Control  
- `PlayerMovement.cs` / `PlayerMovementIntermediaire.cs`: Handle movement, jumps, death logic, and key/door interactions.  

### 🔑 Object Interactions  
- `KeyPickUp.cs` / `KeyPickUp1.cs`: Collect keys and update state.  
- `DoorTrigger.cs` / `DoorTrigger1.cs`: Check for key possession and trigger victory screen.  

### 🖥️ UI Management  
- `DeathPanelController.cs`: Restart after death.  
- `VictoryRetour.cs`: Return to main menu after victory.  
- `MenuController.cs`: Navigation between levels.  

### ✨ Visual Effects & Animations  
- `FloatKey.cs`: Floating oscillation of keys.  
- `FlipOnDirectionChange.cs`: Enemy movement animation.  
- `FadeOnKey.cs`: Fade effect when collecting a key.  

---

## ⚙️ Methodology  
The development process included:  

1. **Game Design**: Define level difficulty, environment, and player objectives.  
2. **Script Modularity**: Split responsibilities (movement, UI, interactions, visual effects).  
3. **Bug Handling**: Fix animation triggers, collisions, and UI synchronization.  
4. **Testing**: Validate transitions between levels, respawn mechanics, and victory conditions.  

---

## 🧪 Results  

- A fully functional **3-level platformer game** with modular code.  
- Smooth **animations and effects** (floating keys, fade effects, enemy patrols).  
- Robust **UI system** (death panel, victory screen, menu navigation).  

**Key Insights**:  
- Modular scripting simplified debugging and made teamwork efficient.  
- Collision handling (vertical vs. horizontal) was the main technical challenge.  
- Clear separation between **game logic** and **UI logic** improved code readability.

--- 

## 🚀 Future Improvements  

- Add decorative assets (tools, gems, rocks) to enrich the cave environment.  
- Implement avatar selection and player customization.  
- Introduce new abilities (crouch, sprint).  
- Expand with more enemies, traps, and complex levels.  
- Add background music and sound effects for immersion.  
- Develop a **multiplayer mode** inspired by *Fireboy and Watergirl*.

---

## 📸 Screenshots  

Here are some in-game screenshots of **EsCave**:  

![Menu](Images/Escave%20(1).png) 
*Creation of the difficult scene*

![Easy Level](Images/Escave%20(2).png)   
*Main menu with level selection*  

![Intermediate Level](Images/Escave%20(3).png) 
*Collecting a key in Easy level* 

![Hard Level](Images/Escave%20(4).png)  
*Victory panel after completing a level* 

![Victory Screen](Images/Escave%20(5).png)  
*Avoiding traps in Hard level* 

![Death Panel](Images/Escave%20(6).png)  
*Gameplay in Intermediate level*  
