INCLUDE ../../globals.ink
EXTERNAL updateQuest(questId)
EXTERNAL playItemAnim(itemAnim)
EXTERNAL putInInventory(itemName)
EXTERNAL takeOutInventory(itemName)

~ updateQuest("FindKeyQuest")
{ toilet_opened == false: -> toilet1 | -> toilet2 }

=== toilet1 ===
    It's an old toilet with cover closed.
        + [Open it]
        ~ playItemAnim("ToiletOpened")
        ~ toilet_opened = true
    You opened it.
    There is a shiny object at the bottom of the toilet, what is that? #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker
    It's too deep to reach... #speaker: White Mouse #portrait:white_rat_normal #layout:speaker
-> END

=== toilet2 ===
    
    { has_plunger == false: -> no_plunger | -> with_plunger }
    
    === no_plunger ===
    Maybe we can find some stuff to help us pull it out? #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker
    -> DONE
    
    === with_plunger ===
    
    { has_bathroom_key == false: -> no_bathroom_key | -> with_bathroom_key}
    
    === no_bathroom_key ===
    Let's try to use the plunger! #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker
        + [Use the plunger]
    ~ takeOutInventory("Plunger")
    You used the plunger to pull it out.
    ~putInInventory("Key")
    It is a key! Maybe we can use it on a door? #speaker: White Mouse #portrait:white_rat_normal #layout:speaker
    ~ has_bathroom_key = true
    -> DONE
    
    === with_bathroom_key ===
    It's an old toilet with cover opened.

-> END




