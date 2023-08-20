INCLUDE ../../globals.ink
EXTERNAL updateQuest(questId)
EXTERNAL takeItem(itemName)

-> main

=== main ===
There is a plunger at the corner of the room, must be used for the toilet.
    + [Take it]
        -> chosen("took the plunger")
        
=== chosen(action) ===
~ takeItem("Plunger")
~ updateQuest("FindKeyQuest")
~ has_plunger = true
You {action}.


I see, we can unplug the stick on this stuff and use the bottom as a bowl, you are so clever! #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker

-> END