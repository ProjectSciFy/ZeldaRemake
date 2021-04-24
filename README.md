# ZeldaRemake
README Document for Sprint 3:

Program Controls:
	-[WASD] and [Arrows] keys control vertical and horizontal movement.	
	-[LShift] causes Link to lunge/roll in the direction he is looking. Lunging/rolling through enemies will make Link invulnerable.
	-[N] and [Z] cause Link to attack with his sword.
	-[X] and [M] cause Link to attack with his selected secondary weapon (bomb/bow and arrow/boomerang).
	-[C] causes Link to use his portal gun. If Link is in a room with a hidden portal, using the portal gun will reveal the portal.
	-[T] causes a red keese to spawn. This is Link's little helper.
		+The little helper is controlled by the mouse cursor. It will follow the cursor where it is in the game.
		+The little helper can block enemy movement as well as pick up items and carry them to Link. 
		+The little helper can deflect and break projectiles.
	-[I] enters the item selection screen; pressing [I] again leaves this state.
		-[P] pauses the game; clicking [P] again will resume the game. 
	-[2]...[4] cycle through Link's secondary weapons and update HUD to reflect current secondary weapon.
		+Left clicking on items in the item selection screen ([I]) has the same effect.
	-[Q] and [esc] quit the game instantly.
	-[R] resets game to starting state. This is for testing purposes and will be removed in the final version of the game.
	-[K] gives Link 5 keys instantly. This is for testing purposes, or if you want an easy way out.
	-Left clicking doors will cycle through rooms in the direction of the door clicked.


Game Features (Sprint 5 Extra Features):
	-Added a new room for Redead enemies and Fog of War.
	-New type of enemy: Redead enemies.
		+Redead enemies spawn in only one room.
		+Redead enemies stun Link for a short time.
	-Added Fog of War in the room with Redead enemies. There is no way to toggle this.
	-Added little helper. Behavior described above in Program Controls under [T].
	-Added portals and portal gun.
		+Portals can be used as doors once discovered and opened.
	-Added lunge/roll.
	-Added XP and leveling.
		+After killing enemies, either a random item drops or an XP orb.
		+Picking up 10 XP orbs will allow Link to level up. 
		+Leveling up allows Link to deal more damage to enemies.
	-Removed Old Man and replaced him with Roshi boss.
		+Roshi shoots a horizontal blast that kills Link instantly if it hits.
		+Roshi occasionally shoots fast small fireballs at Link. These can be easily dodged.
		+After getting Roshi to a certain HP, Roshi charges up an explosion that will instantly kill Link unless Roshi is killed.
		+Roshi drops a key when killed.
	-Added an Event tile in Roshi's room.
		+Once triggered, all doors in Roshi's room are locked.
		+Once triggered, the Event cannot be trigged again unless game is reset.