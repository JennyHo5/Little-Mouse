INCLUDE ../../globals.ink
EXTERNAL takeItem(itemName)

Two bottle of wines on the floor. They are all half empty.

Can I try it, White Mouse? #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker

+[Try it]
    ->try_it
+[Don't try it]
    ->dont_try_it

=== try_it ===
Sure, I'll give it a shot! It's my first time trying alcohol, I'm a bit nervous ... #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker

Glek, glek, glek... #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker

~takeItem("Alcohol")

Damn, it tastes like pee! I was wondering why human likes drinking this... #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker

->end

=== dont_try_it ===
Nah, I have already reached legal age in mouse life, I'll try it anyways! #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker

Glek, glek, glek... #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker

~takeItem("Alcohol")

Damn, it tastes like pee! I was wondering why human likes drinking this... #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker

->end

===end===
I feel a bit dizzy now... #speaker: Black Mouse #portrait:black_rat_normal #layout:speaker

-> END