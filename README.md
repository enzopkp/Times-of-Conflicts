# Times-of-Conflicts
![image](https://user-images.githubusercontent.com/93856977/140939167-f2710109-f9a8-4159-bb48-042faaa33a92.png)

# Gameplay

Based on Age Of War, Times of conflicts is an epic base defense strategy game where you fight a continuous war. The objective is to destroy the enemy's base by summoning different types of units. Using the SplashKit library, I was able to recreate as closely as possible. 
Some of the features I successfully implemented are:
- Summoning of different types of units with different stats
- Possibility to upgrade the player's base for additional health & self-defense capability
- Pause menu upon pressing of the P key
- Win menu upon victory
- Loss menu
- Enemy random actions
- Units travel in a queue 
- Units fight upon contact with enemy entity
- Units & upgrades cost money
- Several design patterns were used for code readability, efficiency and upgradability
- Responsive bitmaps for castles dependant on their health 
- Simple and eye-catching user interface
- 
Without further due, here are some of the different features explained in more details.
# Start menu:
![image](https://user-images.githubusercontent.com/93856977/140720944-4abd5b89-fb7c-4e08-b508-588e2479b24b.png)

On this screen, the user is given the possibility to start the game by pressing the button.

# Pause screen:
![image](https://user-images.githubusercontent.com/93856977/140724077-1c302832-4669-477c-900f-91c5882a691f.png)

On this screen, the user is given the possibility to restart, quit or resume the game.

# Loss screen:
![image](https://user-images.githubusercontent.com/93856977/140724106-0361f167-1cba-4226-9994-a7254aef6b46.png)

On this screen, the user is given the possibility to restart or quit the game.

# Win screen:
![image](https://user-images.githubusercontent.com/93856977/140724140-129b2ef6-e3c5-4730-9d22-bee0d22e3e92.png)

On this screen, the user is given the possibility to restart or quit the game.

# Singleton design pattern:
[GameSingleton.cs]
![image](https://user-images.githubusercontent.com/93856977/140724193-36690a72-d0e0-4526-9c4f-03cb088668bd.png)

In this class, the implementation of the singleton design pattern is done. It is a thread-safe, lazy instantiation that does not use locks. In other words, this instantiation of the singleton design pattern is engineered for multi-threading applications. It also uses the lazy initialization concepts, which means the singleton is not created until it is first used. This implementation of a singleton is proved to be very efficient in terms of performance and safety of execution as opposed to a lot of other variants of such design pattern.

# Factory design pattern:
[CastleBuilder.cs]
![image](https://user-images.githubusercontent.com/93856977/140724305-c5990756-9d4f-40bb-abec-2b1db1c67cf2.png)

In this class, we can see the implementation of a factory design pattern. This design pattern is a creational pattern providing , in the singleton both functions aimed at creating the player's castle and the enemy castle are sequentially called. This class is tasked with creating each object with its different characteristic, using the Castle class as a blueprint.  

# Strategy design pattern:
[Enemy.cs]
![image](https://user-images.githubusercontent.com/93856977/140724376-b0c99e01-00ba-4cd2-8aae-c21f3839b2db.png)
[IStrategy.cs]
![image](https://user-images.githubusercontent.com/93856977/140961505-a9a638cf-f95a-47b5-9a95-94b06e0d66da.png)
[AddMelee.cs]
![image](https://user-images.githubusercontent.com/93856977/140961557-4db2568e-0e10-4bd9-a00f-f1598ca91a8f.png)

A strategy pattern is a behavioural design pattern that allows the code to chose the algorithm to execute between a range of algorithms at runtime. This is done through the implementation of a context class (Enemy.cs), interacting with an interface (IStrategy.cs) which is common to all strategies. It allows the context class to select the desired strategy (AddGiant.cs, AddMelee.cs, AddRange.cs, Upgrade.cs). Upon execution of the DoSomething() method in Enemy.cs, the code will randomly determine a strategy to use, and its logic will then be executed through the Do() method existing in the IStrategy.cs interface.
