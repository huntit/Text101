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
		text.text = "Nope Using a mirror to look at these festy sheets doesn't help with the " +
					"smell at all. And you still can't think of a way to use them to get out.\n\nPress " +
					"R to return to roaming your cell.";
		if (Input.GetKeyDown ("r")) 		{myState = States.cell_mirror;}
	}

	void state_mirror(){
		// Text for looking at the broken mirror. Comes from the cell state and returns to the cell_mirror state
		// if the mirror is taken.
		text.text = "This mirror was totally broken before you got here. It definitely wasn't your fault! Although " +
					"now that you at yourself in the mirror, your reflection fractured like your soul it occurs " +
					" to you that it could be useful to grab a shard.\n\nPress T to take a mirror shard. Press R to return to roaming your cell.";
		if (Input.GetKeyDown ("r")) 			{myState = States.cell;}
		else if (Input.GetKeyDown ("t")) 		{myState = States.cell_mirror;}
	}

}