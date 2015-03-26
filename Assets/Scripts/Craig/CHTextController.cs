using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CHTextController : MonoBehaviour {

	public Text text;

	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;

	// Use this for initialization
	void Start () {
	
		myState = States.cell;

	}

	// Update is called once per frame
	void Update () {
		print (myState);
		// Checks the current state and calls the appropriate method.
		if (myState == States.cell) 			{state_cell();}
		else if (myState == States.sheets_0)	{state_sheets_0();}
		else if (myState == States.sheets_1)	{state_sheets_1();}
		else if (myState == States.mirror)		{state_mirror();}
		else if (myState == States.lock_0)		{state_lock_0();}
		else if (myState == States.lock_1)		{state_lock_1();}
		else if (myState == States.cell_mirror)	{state_cell_mirror();}
		else if (myState == States.freedom)		{state_freedom();}
	}
	void state_cell(){
		// Text for standing in the cell. This is the start game state.
		text.text = "You are trapped in a dank, dirty prison cell. For the past two weeks, rats have been " +
					"your only companions. But now you've reached the end of your conversational tether and " +
					"have decided that it's time to get out of here. There are some dirty sheets on a bed, " +
					"a broken mirror on the wall, and the cell door is locked from the outside.\n\n" +
					"Press S to look at the sheets, M to look at the mirror, L to look at the lock.";

		if (Input.GetKeyDown ("s")) 		{myState = States.sheets_0;} 
		else if (Input.GetKeyDown ("l")) 	{myState = States.lock_0;}
		else if (Input.GetKeyDown ("m")) 	{myState = States.mirror;}
	}

	void state_cell_mirror(){
		// Text for standing in the cell after taking the mirror shard.
		text.text = "So you're still stuck in a dirty, dank cell. And you're still starved of conversation " +
					"You're pretty sure your plan is still to escape this place. Only now you have a shard of mirror " +
					"to help you enact your amazing escape plan. \n\nPress S to look at the sheets, L to look at " +
					"the lock.";

		if (Input.GetKeyDown ("s")) 		{myState = States.sheets_1;} 
		else if (Input.GetKeyDown ("l")) 	{myState = States.lock_1;}
	}

	void state_sheets_0(){
		// Text for looking at the sheets on the bed pre-mirror. Comes from cell state.
		text.text = "You've been sweating in these sheets for two weeks now and they still haven't been " +
					"taken for cleaning. And they started off rather damp and smelly in the first place. You don't " +
					"see any way to use them.\n\nPress R to return to roaming your cell.";

		if (Input.GetKeyDown ("r")) 		{myState = States.cell;}
	}

	void state_sheets_1(){
		// Text for looking at the sheets on the bed post-mirror. Comes from cell_mirror state.
		text.text = "Nope. Using a mirror to look at these festy sheets doesn't help with the " +
					"smell at all. And you still can't think of a way to use them to get out.\n\nPress " +
					"R to return to roaming your cell.";

		if (Input.GetKeyDown ("r")) 		{myState = States.cell_mirror;}
	}

	void state_mirror(){
		// Text for looking at the broken mirror. Comes from the cell state and returns to the cell_mirror state
		// if the mirror is taken.
		text.text = "This mirror was totally broken before you got here. It definitely wasn't your fault! Although " +
					"now that you at yourself in the mirror, your reflection fractured like your soul, it occurs " +
					" to you that it could be useful to grab a shard.\n\nPress T to take a mirror shard. Press R " +
					"to return to roaming your cell.";

		if (Input.GetKeyDown ("r")) 			{myState = States.cell;}
		else if (Input.GetKeyDown ("t")) 		{myState = States.cell_mirror;}
	}

	void state_lock_0(){
		// Text for looking at the door's lock without the mirror. Comes from the cell state.
		text.text = "So it looks like some kind of push-button combination look. Perhaps if you had some way to " +
					"look at the keys via some kind of reflection, maybe you could see which keys numbers have " +
					"worn off from overuse . . . If only . . .\n\nPress R to return to perusing your cell.";

		if (Input.GetKeyDown ("r")) 			{myState = States.cell;}
	}

	void state_lock_1(){
		// Text for looking at the door's lock with the mirror. Comes from the cell_mirror state. Leads to Freedom state.
		text.text = "Huh. It seems like this shard of mirror could be used to look at the keypad outside the door. " +
					"And what do you know? The only key that's worn out is the 9. I guess there can't be too many " +
					"4 to 6 digit combinations using only the number 9 . . .\n\nPress R to return to perusing your " +
					"cell because you just don't get it.\nPress U to try unlock the cell by repeatedly pressing 9.";

		if (Input.GetKeyDown ("r")) 			{myState = States.cell_mirror;}
		else if (Input.GetKeyDown ("u")) 		{myState = States.freedom;}
	}

	void state_freedom(){
		// Text for unlocking the door and escaping your cell. Comes from the lock_1 state.
		text.text = "Holy cow! It was an eight-digit combination! That could have been impossible to crack. Luckily " +
			"they left it as the manufacturer's default of '99999999'. And now you're out and free to run " +
			"and skip in the sunshine. Congratulations!\n\nPress R to drop the mirror, walk back into your " +
			"cell (pulling the door closed behind you), and starting all over again.";

		if (Input.GetKeyDown ("r")) 			{myState = States.cell;}
	}
}