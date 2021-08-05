# 0x02. Unity - Scripting

# Learning Objectives
* What are scripts in Unity and how are they created and used
* How to control GameObjects with scripts
* What is an event function and how are the most common ones used
* How to create and destroy GameObjects within scripts
* How to use namespaces to organize classes
* What are attributes and how to use them
* How to use ```Debug.Log()```
* What is a vector

## 0. Ready player one
Clone [this repository](https://github.com/holbertonschool/0x02-unity-scripting) containing a ```maze``` Unity project. You will build on this project by adding new GameObjects and scripts to create a ```playable game```. This project should be pushed to its own repo called ```0x02-unity-scripting```, <b>not</b> within a subdirectory.
Inside the ```maze``` scene, create a Sphere GameObject named ```Player``` with a Rigidbody component.
* Position: ```(23, 1.2, 16)```
* Scale: ```(2, 2, 2)```
* Material Name: ```player```
* Material Color: ```#0000FFFF```

## 1. Bust a move 
Create a directory ```Scripts```. In this directory, create a new C# script called ```PlayerController.cs```. Attach this script to the ```Player``` object. Within this script, update the ```Start()``` and ```FixedUpdate()``` functions to allow the ```Player``` to move when either the WASD or arrow keys are pressed
* Movement should only be on the X and Z axes – the Player should not be able to jump.
* There are many ways to create player movement depending on the way you want your player to behave. The way you implement player movement is up to you, as long as it is possible for Player to move through the maze.
* Create a ```public float speed``` variable that can be edited in the Inspector to easily modify the Player‘s speed. The value of the Player’s speed is entirely up to you and how you implement player movement.

## 2. Camera ready 
Move the ```Main Camera``` to position ```(22, 26, 7)```. Create a new C# script in the Scripts directory called ```CameraController.cs```.
* The script should have a ```public GameObject player``` variable that can be edited from the Inspector window.
* The camera should follow the Player as it moves. In other words, when the player moves, the camera’s Transform position should also change relative to the Player.
* The camera’s position should remain at a constant offset from the Player‘s position.
* The camera does not need to rotate.

## 3. Insert coin 
Create a new Cylinder GameObject named ```Coin```.
* Position: (27, 1.7, 24)
* Rotation: (0, 0, 90)
* Scale: (1, .05, .8)
* Material Name: coin
* Material Color: #FFFF00FF
* Tag: Pickup
* The Coin‘s Collider component should have Is Trigger checked (Why?)
* Turn Coin into a prefab inside a directory called Prefabs

## 4. Coin collecting 
Create a new C# script called ```Rotator.cs``` and attach it to ```Coin```.
* Within the Update() function, change the x value of the Coin‘s rotation to 45 over time.
* Hint: Time.deltaTime
Add a new private int score variable to your PlayerController script. Set the initial value of score to 0.

Add the following new function to the script:

* Prototype: void OnTriggerEnter(Collider other)
* This function should increment the value of score when the Player touches an object tagged Pickup
* Write the new value of score to the console using Debug.Log() with the format Score: <value>
* The Coin object should be disabled or destroyed after the Player touches it
Place at least 20 total Coins within the maze in any X / Z position you like, as long as they are visible to the player. Keep the Y position at 1.7 to ensure the player can reach them.

Create an empty GameObject named Coins to contain all the Coin objects in the Hierarchy window. Make sure the new empty GameObject’s Scale values are all set to 1 before dragging the Coin objects into the Coins object to avoid issues with the coins’ scaling and rotation.

## 5. Danger zone 
Create a new Plane GameObject named ```Trap```.
* Position: (9.5, 0.26, 27)
* Scale: (0.5, 1, 0.5)
* Material Name: trap
* Material Color: #FF0000FF
* Tag: Trap
* The Trap‘s Collider component should have Convex and Is Trigger checked (Why?)
* Turn Trap into a prefab inside the Prefabs directory

## 6. You've activated my trap card 
Add a new ```public int health``` variable to your ```PlayerController.cs``` script. Set the initial value of ```health``` to ```5```.
  Add to the existing void OnTriggerEnter(Collider other) function:

* his function should decrement the value of health when the Player touches an object tagged Trap
* Write the new value of health to the console using Debug.Log() with the format Health: <value>
Place at least 8 total Traps within the maze in any X / Z position you like, as long as they are visible to the player. Keep the Y position at 0.26 to ensure the player can touch them.

Create an empty GameObject named Traps to contain all the Trap objects in the Hierarchy window.

## 7. The finish line 
Create a new Plane GameObject named ```Goal```.
 * Position: (-27, 0.26, 1.8)
* Scale: (0.5, 1, 0.5)
* Material Name: goal
* Material Color: #00FF00FF
* Tag: Goal
* The Goal‘s Collider component should have Convex and Is Trigger checked

## 8. Goaaaaaaaaaaal 
In ```PlayerController.cs```, add to the existing ```void OnTriggerEnter(Collider other)``` function.
  * When the Player touches an object tagged Goal, write You win! to the console using Debug.Log()

## 9. Game over 
Create an ```Update()``` function within ```PlayerController.cs```.
  * This function should check if health equals 0. If it does, write Game Over! to the console using Debug.Log()
* If health equals 0, reload the scene so that the Player starts again from the beginning
* The Player‘s health and score should reset to their original values
* You may have issues with the lighting preview in Unity when testing and reloading your scene. For more information, watch Fix Lighting Going Dark in the Unity Editor When Resetting a Scene
