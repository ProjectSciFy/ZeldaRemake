README Document for Sprint 2:

Things to Note About Performance:
	-Goriya's boomerangs spawn in a very delayed cycle.
	-Eevee from Sprint 0 is still in the project, PLEASE IGNORE WE WILL REMOVE LATER. IT'S CUTE.

Program Controls (and some incomplete/buggy issues stemming from controls):
	-[WASD] and [Arrows] keys control vertical and horizontal movement.
		+No diagonal movement. Key priority-based movement (i.e.: last key pressed is the direction link moves; if key is held and another is pressed, he moves in the new direction)
	-[T] and [Y] cycle through tile/block textures
	-[U] and [I] cycle through item textures
	-[O] and [P] cycle between enemies
		+Some enemies have unique actions such as fireball attacks and randomized movement. This will be updated in the future to adapt to the realities of our game as it evolves.
	-[N] and [Z] are not implemented -- instead, key [1] performs the animation for link's sword attack.
	-[1]...[4] are meant to cycle between link's items and their respective animations; the use item animation mostly works but the item itself (except for key [1]) does not spawn yet. We will fix this.
	-[E] performs the damaged animation on link. He pauses all other actions to take damage.
	-[R] resets all sprites to original locations and states.
		+KNOWN ISSUE: if [E] is press directly before resetting with [R], Link's damaged animation continues past the reset and then resets.
	-[Q] quits the game instantly.

Extra Implementations:
	-[1]...[4] change Link's item AND perform the intended items' animations. Currently the items are not spawning, but their animations are coded.