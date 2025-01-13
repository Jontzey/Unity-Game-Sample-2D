# Welcome!
A small 2D game project building a Quest system where the player can accept an quest from a non playable character and then when all the conditions for the quest is complete, the player can revisit the non playable character and complete the quest to earn experience.



# Content!

Currently the code has been rebuilt, Updated the Quest system for more structure.

1. Can Accept a quest from a Npc with a userinterface
2. If Quest is accepted and player interacts with npc again, the userinterface will show in progress.
3. When All Quest conditions are fullfilled the quest is Complete and when player interacts with the npc again the userinterface will be diffrent as well change the behavior on complete button and give the player a reward with experience.

# Quests!

The only quest for now is collect item kind of quest, but can be reused depending on how you write the code.

Quest 1 : collect 10 Apples.

Quest 2 : collect 10 Bannans.

The Quest information will be set in the npc like "QuestId","QuestName","Description", "CurrentAmount","RequiredAmount".
- The Quest id will be helpful when finding what to update and how quest item should behave.

When a Quest is being added from an npc, it will be added to a QuestManager which will hold all active Quests

 
