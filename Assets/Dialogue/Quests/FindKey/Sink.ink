INCLUDE ../../globals.ink
EXTERNAL updateQuest(questId)
EXTERNAL takeItem(itemName)
EXTERNAL showItem(itemName)

It was a normal sink, with a door under it.

+[Look up to the sink]
    ->LookUp
+[Open the door]
    ->OpenWardorbe

===LookUp===
There is an emptied bottle next to the sink, and white liquid flowed from the bottle onto the floor.
There are also some other stuff: a yellow soap, and a mouthwash cup with one toothbrush in it.

->DONE

===OpenWardorbe===

{has_plunger == false: -> with_plunger | -> no_plunger }

===with_plunger===
There are some cleaning tools in the wardorbe.
~ showItem("Plunger")
You found a red plunger.
->DONE

===no_plunger===
There are some cleaning tools in the wardorbe.


->END