# 0x03. Unity - UI

# Learning Objectives
* What is the Canvas
* What is screen space vs world space
* How to use the Rect Tool
* What are anchors and how to use them
* How to display and update information in the UI
* What is a coroutine
* How to create a menu
* How to use Unity’s UI Interaction Components
* What the alpha value of a color is
* How to set and change material colors with scripts
* What are common accessibility concepts to consider

## 0. Scoreboard
We’ll be building off the last project to add UI elements (see example).

Clone your ```0x02-unity-scripting``` repo into a new repo called ```0x03-unity-ui```. Like the previous project, this project should be inside its own repo, not within a subdirectory.

## 1. What does "new high score" mean? Is that bad? Did I break it? 
Edit the ```PlayerController.cs``` script. Create a new ```public Text scoreText``` variable. In the Inspector, set the value of the ```scoreText``` field to your ```ScoreText``` GameObject.

## 2. HP 
Inside the existing Canvas GameObject, create a new UI Image GameObject and name it ```HealthBG```. Anchor it to the top left of the game window using Anchor Presets.

## 3. Health inspection 
Edit the ```PlayerController.cs``` script. Create a new ```public Text healthText``` variable. In the Inspector, set the value of the healthText field to your ```HealthText``` GameObject.

## 4. Win, lose, or draw 
Inside the existing Canvas GameObject, create a new UI Image GameObject and name it ```WinLoseBG```. Anchor it to the center of the game window using Anchor Presets.

## 5. Chicken dinner 
Edit the ```PlayerController.cs``` script so that when the ```Player``` touches the ```Goal:```

## 6. Game over, man, game over
Edit the ```PlayerController.cs``` script so that when the ```Player```‘s ```health```reaches 0:

## 7. Wait a second... 
The transition from the ```Game Over!``` text and the scene reloading is very sudden and abrupt. Let’s use a coroutine and ```WaitForSeconds()``` to create a delay where once the Player‘s health is 0 and the ```Game Over!``` text is displayed, the scene waits ```3``` seconds to reload.

## 8. What's on the menu 
Create a new scene called ```Menu``` in the Project window. Add a new UI Panel GameObject called ```MenuBG```

## 9. Let's play 
Create a new C# script ```MainMenu.cs```. Create a new method ```public void PlayMaze()```.

## 10. We're not retreating, we're advancing! Toward future victory! 
Inside the ```MainMenu.cs``` script, create a new method ```public void QuitMaze()```.

## 11. A narrow variety of options 
Inside the existing Canvas GameObject, create an empty GameObject called ```OptionsMenu```. Anchor it to the center of the game window with Anchor Presets.

## 12. Accessibility 
Having red traps and a green goal isn’t very accessible design for certain types of colorblindness. Ideally in game design, it would be better to avoid color coding important mechanics or objects entirely. For the sake of this UI project, we’ll add a Colorblind Mode option for our maze.
