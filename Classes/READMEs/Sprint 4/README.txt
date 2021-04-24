# ZeldaRemake
README Document for Sprint 3:

Known Bugs:
	-Rare situtation in which enemies block doorways upon leaving rooms makes it impossible to re-enter room.
	-Attempts to door mouse to transition through rooms may cause Link to get stuck in door; fix this by pressing [K].
	-Clicking on segments of wall where a door goes (but the texture is that of a wall) sometimes attempts to transition in that direction. Only happens if there is an actual room that way.
	-Confusion surrounding ItemSelectionState scrolling made implementation difficult; therefore this has not been fully implemented.

Program Controls:
	-[WASD] and [Arrows] keys control vertical and horizontal movement.
		+No diagonal movement. Key priority-based movement (i.e.: last key pressed is the direction link moves; if key is held and another is pressed, he moves in the new direction).	
	-[N] and [Z] cause Link to attack with his sword.
	-[X] and [M] cause Link to attack with his selected secondary weapon (bomb/bow and arrow/boomerang).
	-[2]...[4] cycle through Link's secondary weapons and update HUD to reflect current secondary weapon.
	-[P] pauses the game; clicking [P] again will resume the game. 
	-[Q] and [esc] quit the game instantly.
	-[R] resets game to starting state. This is for testing purposes and will be removed in the final version of the game.
	-[K] gives Link 5 keys instantly. This is for testing purposes and will be removed in the final version of the game.

	-MOUSE CONTROLS:
		+Left clicking doors will cycle through rooms in the direction of the door clicked.


Program Future Implementations:
	-Implement ItemSelectionState and visuals, caused by pressing [I].
	-Implement a fully operational Bow (loot) room (room number 16 with our numbering system).
	-Implement hidden doors that appear after Link explodes a bomb near them.
	-Implement sliding blocks.


Program Extra Implmenetations:
	-We have developed a Fairy item that flies around the room and can give link an extra healthy boost.