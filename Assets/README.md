# Go Felix! 
### A brief guide to this project 

Hi! And thank you for considering the idea of creating a minigame for  **Go Felix!**

Go Felix! Is a game development project born from a silly idea that sparked in the Autumn 2023 PlayLab course, taught by Prof. Miguel Sicart at the IT University of Copenhagen.

The best way to describe this project is by calling it a **WarioWare-Like**. It's going to be a collection of minigames created by... whoever, really. You just need a bit of experience using Unity. 



First of all, you can download the project by simply cloning the repository or downloading it as a zip file. The project is developed in **Unity 2022.3.8f1**. 



We are committing to maintain this project and keeping it tidy, so we would really appreciate if you could comply to some guidelines we created that *should* make our work proceed more smoothly.

|Rule| Why  |
|--|--|
|Use the correct version of unity. It is the **2022.3.8f1** version.| Having to upgrade or downgrade your project would cost lots of time and possibly corrupt / change some of your assets, creating undesired and unexpected results. |
| Refrain from creating, deleting, or moving around any file in the **00 DO NOT TOUCH (please)** folder. | All of the project settings, core scripts, scenes, sprites, etc. are located here. ***Feel free to copy these files in other locations and reuse them!***  |
| Create a folder inside the **02 YOUR GAME(S) HERE** for each of your minigames. You can find some examples of minigames in there already. All of the assets related to the minigame should be located in their respective folder. Again, you can peek at already existing minigames.  | It's very easy to get assets mixed up. But most importantly it's very easy to run into conflicts when merging your minigames in the main branch of the game. Having everything in different folders gets rid of this problem entirely. |
| The use of Unity tags and physics layers is prohibited. We know it's a strong limitation, but we're going to have to ask you to change your code to not use them if you do, before we can merge your minigame. We know it's inefficient, but consider using gameobject names instead of tags, and more complex collision conditions instead of physics layers. | Tags and Physics Layers are not scene or folder dependant in Unity: they are project wide, and can be easily overwritten. This is very time consuming and complicated to maintain if this project grows in scale.|
| Use specific names for your script rather than generic ones. For example, if your project's name is "UnderFelix" and you need to create a "Spawner" object, prefer calling it "UnderFelix_Spawner". An alternative to this is using Namespaces in C#. Please find documentation about namespaces [here](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/namespaces). | Again, when creating such short games and in such a short timespan, it's easy to trip in the pitafall of using generic names. It's rather easy then to have Classes and Monobehaviours with the same names creating errors which we would have to fix manually, losing lots of time.|
