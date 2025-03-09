# LBoL-ExhibitRebalance
A Mod that rebalances Exhibits in LBoL to try and make elites more worthwhile

# Full Changelist:
## Reworked Exhibits
- Computer parts: Now increases your spellcard stock by 1, and gives 100 power on pickup. (Existing effect moved to the Tea Set)
- Tengu's Camera: Now applies 1 Firepower Down to each enemy at the start of combat
This and lightsaber did approximatly the same thing, so I changed the camera to give it it's own identity. This effect also more clolely resembles how the camera works in StB
- Shiny Bulb: Has Helium-3's old effect, but gives Green mana instead of Colourless
This movement was for a few reasons. Firstly, after moving ribbon and pocketwatch to rare, I wanted to finish the new mana generating cycle with playable character themed exhibits. Secondly, with those exhibits and the new peach there was a lot of mana generation at rare now even without a seperate heliem. Lastly, I simply didn't have any more good ideas for this slot. Thinking isn't anywhere else yet because I didn't know a good place for it.
- Helium-3: At the start of your turn, add the topmost card in your draw pile with a total mana cost of exactly 3 to your hand. Uncommon Shop
A complety new build around effect to use the space avalible, I expect this to be a very powerful tutoring effect in the correct deck.
- Super Mushroom: At the start of your turn, if you have 25 or more cards in the hand, draw pile and discard pile combined, gain R mana. Shop Only Common.
A new effect to fill out the shop mana gain cycle now that Ribbon and Pocketwatch have changed pools. This one rewards you for being big. I may have set the requirement too high and am willing to lower it if that's the case,
- Exquisite Tea Set: Now automatically heals you for 15% of your life when entering a gap. When drinking tea, you gain 50 power.
Now acts as an automatic heal instead of trying to buff tea directly, you instead get power for sipping to make the command less useless. this steps on Wooden Fish's toes as there's always a gap before the boss, so that got reworked to...
- Wooden Fish: When a card exiles one or more other cards, gain W mana. Shop Only Common.
A new member of the shop mana gain cycle. This rewards cards like purify the land and Devil's codex, but only gives 1 mana per card play and doesn't pay for cards that exile themselves.

## Buffed Exhibits
- Peach: Now also gives you C at the start of each turn if your life is at maximum
- Black Notebook: Now does 25 dmaage multiplied by the current act number, so 25 in act 1, 50 in act 2, 75 in act 3 and 100 in act 4. Is no longer limited to the shop.
- Vinyl: Now also gives Mana when you draw a Misfortune
- Huge Spoon: Now gives 13 max life, now gives you max life for each existing misfortune when collected.
- Lightsaber: Now applies 4 lock-on, is no longer restricted to the shop pool
- Hyottoko Mask: Now gives 10 block (from 5), is now a common Shop Only exhibit.
- Apple: Now also gives 1 ward at the start of combat. Is now Common.
- Delicious Cookie: Now fully charges Power on pickup. 
- Just-a-Knife: Now adds 5 damage to 1 cost basic atatcks and 10 to 2 cost basic attacks. Is now a shop only exhibit
Credit to rm -rf Maxx C for the numbers and code
- Grapes: Added "The first time you take lose life each combat, gain twice that much life as Power"
- Anesthesia Gun Watch: Now consistently applies both debuffs, Is now Uncommon and no longer limited to shops.
- Inchling's bowl: Added "The first time you play a basic card each turn, draw a card". Moved to Common.
Once per turn to avoid any stupid magic of the mallet shoot boundry infinites.
- Butter Robot: Added "On the 2nd and 3rd turn of combat, add a random rare card to your hand. it has Exile and Ethereal"
Practically a rework, I chose the 2nd and 3rd turns to avoid having more first turn hand fill. This might be a little strong for common but random, undiscounted cards are hard to value. 
- Donation Box: Now gives +10 money when skipping cards (from +5)
- TNT: Now activates on the second turn of combat, and is a common shop exhibit.
Intended to be an exhibit based solution to AoE, the timer moved down to be more reliable and it's in the shop to avoid disrupting expel attempts and just because a lot of decks don't care.

## New exhibits
In order to fill out a new protaganist rare mana gain exhibit cycle, 2 new exhibits were created.

- Bewitched Broom: Whenever the player recieves a debuff, gain B mana. Rare Anywhere.
- Frozen Frog: At the start of your turn, except the first turn of combat, gain U Mana. Rare Anywhere.

## Moved exhibits
Some exhibits merely changed pools and/or rarities.

- Roukanken: Can now appear anywhere
- Bottle: Can now appear anywhere
- Model Robot: Can now appear anywhere, is now Uncommon
- Take-Copter: Can now appear anywhere
- Omikuji: Can now appear anywhere, is now Uncommon
- Hakurei Amulet: Can now appear anywhere
- Membership Card: Can now appear anywhere, is now Uncommon
- Sutra of Dharmatic Power: Can now appear anywhere, is now Uncommon
- Ribbon: Can now appear anywhere, is now Rare
- Silver Pocket Watch: Can now appear anywhere, is now Rare
- Chopper: Is now Shop Only
- Tape: Is now Shop Only
- Crow Tengu's Wing: Is now Shop Only
- Fox Mask: Is now Shop Only and Common
- Hannya Mask: Is now Shop Only and Common
- Mask of hope: Is now Shop Only and Uncommon
- Ibuki Gourd: Is now Shop only and Common
- Lunatic Gun: Is now Shop Only and Uncommon
- Gensokyo Chronicle: Is now Shop only and Common
- Purple Mirror: Is now Shop Only and Uncommon
- Lunar veil: Is now Uncommon
- Ticket to hell: Is now Uncommon
- Spacesuit: Is now Uncommon
- Dowsing Rods: Is now Shop Only and Common
- Broken Amulet: Is now Uncommon
- Sword Of Hisou: is now Uncommon
- Mighty Shaku: is now Common.
- High Grade handbag: is now Shop Only and Common.
Some explaination for this one, as the value varies based on when you get it: if you buy this super early, it's 3 exhibits, but costs a lot of your early money so is a huge risk. If you buy it in early act 2 it's reasonable value as it's 2 worse than average exhibits later, and after act 2 Reisen... I kinda just want it gone as it's worse than a random exhibit by definition.

# Known issues
The reminder that you gain max life from skipping cards when you have incling bowl is missing
The collection does not re-sort the exhibits, but the colours below them match the new rarity

# Future Plans
Dango and the Mighty Shaku are redundent with themselves and the moved bottle, and are slated to be reworked.

New exhibits need better art.

Dowsing rods would ideally be an event exhibit due to the bad value propersition of having an exhibit that needs you to spend gaps to replace itself, likely a second option at the nazrin event, but that requires event editing. Alternativly it could give money in some form but that's redundent with ball of wings, treasure ship model and/or donation box, depending on the implementation

I dislike the current Gensokyo chronicle as it's both potentially infinite healing, and usually pretty bad otherwise, on top of being a spire clone, so it may get reworked if I have a good idea.

I have avoided nerfs to elite pool drops in the initial release, but the "Pay 5 X mana" common cycle has some outliers that really need to be bumped up in rarity (leaf and ice cube), but also includes the generally awkward peony stone (both for being relativly ineffective and a bit annoying past early game and being questionable at best vs Tenshi). A secondary issue with these is that they become bad drops when you only have 1 mana pip of that colour and no philo generation. It may be wise to, when reworking these, make it so they need at least 2 coloured pips to spawn, but to count any natural Philo when doing so.

I am watching the balance of the new exhibits and would appreciate any feedback. I do expect the game to be easier with these changes, but would prefer to restorre difficulty with other mods than to try and nerf things too hard via exhibits.
