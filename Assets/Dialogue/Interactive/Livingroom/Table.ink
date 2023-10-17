INCLUDE ../../globals.ink
EXTERNAL takeItem(itemName)
-> main

=== main ===
It's an old wooden table with some stuff on it.

    +[Take the cheese]
        -> cheese
        
        
=== cheese ===
    ~takeItem("Cheese")
    You took the cheese.
    Oh, look at this cheese! It's been here forever, I bet. It's probably older than my grandma's stories. #speaker: White Mouse #portrait:white_rat_normal #layout:speaker
    What is the thing behind the plate? #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker
    It's a thing called "photo" that a magic human used to freeze the time and record the moment when they are taking it. #speaker: White Mouse #portrait:white_rat_normal #layout:speaker
    I can see two figure on the photo, I wonder if they are the owners of this house. #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker
    But I only saw one toothpaste on the sink in the bathroom. #speaker: White Mouse #portrait:white_rat_normal #layout:speaker
    Hmm...  #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker
    
-> DONE