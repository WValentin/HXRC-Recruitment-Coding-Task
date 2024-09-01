# HXRC-Recruitment-Coding-Task

These are the features I would to add if I were to work on it again:

- A level system:
      I would add a menu with a system of levels. Each level is locked by the one that precedes it.
      I would also rework the way the levels are generated. I would create scriptableObjects to store level data (such as obstacles and collectibles positions) and call a general GameScene with a script that can           take one of these data structures and generate the level depending on it.
      I would add a way to replay previous levels if needed.
  
- A level builder tool:
      In order to make the process of creating levels faster, I would make a tool that helps in the creation of levels, for exemple, by making it possible to quickly place obstacles/collectibles and set them up in         just a few clicks.
      This tool would have the most parameters needed, such as position, rotation direction, size, etc...
      This tool would be as clear and easy to use as possible, so that anyone could be able to use it to make a level.

- New gameplay mechanics on some levels:
      With the level changes I envisioned, I also thought of categorizing levels by groups centered around a mechanic. Of course, each new level could use a mechanic that was seen before.
      Those are the mechanics I can think of:
              - A series of levels where the obstacles turn/move in harmony with the beats of a music (I would use only musics with defined rythms/percussions in order to make it easier for the player. The music                      would loop, and each movement of the obstacles with music would be predetermined)
              - A serie of levels where some obstacles/collectibles are transparent and only show up when a lightning occurs (For this, I would make a panel of UI that is black and change its transparency. I                         would make a timer for the lightnings, and finally I would display the player's ball above that black panel so it can always be seen, with also a change to its material to make it glow a little to                    match the feeling of the levels)
              - A mechanic introducing a new collectible that changes the layout of the level, which would go in pair with a serie of levels where the player can/must go back down to collect all star/complete the                    level (For that, I would mostly set some obstacles as inactive, activate them when it is collected and disable the previous ones. For collectibles, I would make them transparent, so that the player                   knows that they must be collected after changing the layout of the level)
              - A mechanic where the player must stay in a zone for a fixed amount of time without leaving it in order to unlock the path ahead (I would start a timer when the player's ball is inside this                            zone and then reset it if he leaves before the end of the timer. I would also add a visual indicator that tells the progress of the timer)
              - A collectible that makes the player also change the colors of obstacles when he taps the screen (When the player collects this one, I would change a bool inside the ball's code and add a part that                    swaps colors of obstacles with the classic input. I would also add a list of colors to each segment of each obstacle in order to cycle through them when the colors are changed)
              - A series of levels that must be done backward: the ball starts from the top and must fall down to the finish line (I would modify the camera script to invert it, and I would also remove/modify the                     deathzone that was at the bottom of the screen)
              - A serie of levels with a LOT more colors (My code already manages an undefined amount of colors, I would just need to make more obstacles with more colors)
              - A special color switch that gives the ball a new color, but the ball quickly fades to white afterward, so the player has to remember the color (Timer when the player collects the color switch, with a                 gradual change in the color back to white over the duration)
              - Moving collectibles (For exemple, I would make some stars move from right to left, so the player would have to catch it when they can).

- A gamemode with an endless level generated procedurally (For this, I would make some prefab of obstacles/obstacle groups with or without collectibles, I would put them in a list of prefab, and then I would instantiate them a certain distance above the top of the screen, as the player approaches. The other prefabs would be destroyed as they leave the screen at the bottom. I would also implement a system of highscore with this level)
