INCLUDE ../../globals.ink
EXTERNAL startQuest(questId)
EXTERNAL finishQuest(questId)
EXTERNAL takeItem(itemName)

{ has_bathroom_key == false: -> no_key | -> with_key }

=== no_key ===
It's the door of the Bathroom.
    + [Open it]
    ~ startQuest("FindKeyQuest")
    The door is locked... #speaker: White Mouse #portrait:white_rat_normal #layout:speaker
-> DONE

=== with_key ===
Let's try the key we found on this door. #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker
    + [Try the key]
~ finishQuest("FindKeyQuest")
~ takeItem("Door")
It's opened! #speaker: White Mouse #portrait:white_rat_normal #layout:speaker

-> END