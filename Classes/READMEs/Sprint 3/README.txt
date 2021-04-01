# ZeldaRemake
README Document for Sprint 3:

Program Known Bugs:
	-We have not implemented the following collisions:
		+Projectile Collisions
		+Item and Wall Collisions
		+Enemy on Link Collisions (specifically if Link is attacking them)
		+Enemies on items,walls
		+Link on blocks (collision rectangles need adjusting)
	-When clicking through new rooms, the previous room tiles do not get unloaded, potentially causing lag and collision issues
	


Program Controls:
	-[WASD] and [Arrows] keys control vertical and horizontal movement.
		+No diagonal movement. Key priority-based movement (i.e.: last key pressed is the direction link moves; if key is held and another is pressed, he moves in the new direction).	
	-[N] and [Z] cause Link to attack with his sword.
	-[1]...[4] are meant to cycle between link's current held item. UPDATE: [NumPad1]...[NumPad4] have been implemented.
		+Currently, [2]...[4] simply use the item; [2] makes Link place a bomb, [3] makes Link use a bow and arrow, and [4] should make Link use a boomerang although it does not at the moment.
	-[R] resets game to starting state.
	-[Q] and [esc] quit the game instantly.
	-MOUSE CONTROLS:
		+Left clicking will cycle through rooms. You cannot cycle backwards at the moment.
		+Right click closes
Program Future Implementations:
	-Un-implemented collisions will be implemented prior to Sprint 4 submission.
	-Room parser will be cleaned up and refactored.
	-Room transitions will be implemented to display a smooth change.
	-Keep track of rooms loaded
	-Fixing bugs

Program Extra Implementations:
	-We created several items that will become boss loot drops. The drop-rate and actual drop animation is not yet implemented.