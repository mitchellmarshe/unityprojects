/* Prison Escape
 *
 * Author: Mitchell Roger Marshe
 *
 * StateController is a state machine that updates text Script, 
 * text Zone, and image Action in the UI panel by user input flags.
 * The image Title is also set here.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StateController : MonoBehaviour {
	
	public Text script;
	public Text zone;
	public Image title;
	public Image action;
	public Sprite splash;
	public Sprite cell;
	public Sprite cellDoor;
	public Sprite cellPlate;
	public Sprite cellBed;
	public Sprite cellWindow;
	public Sprite cellMate; // cellMateTalk; cellMateNo; cellMateYes;
	public Sprite cellBlock; // cellMateIgnore;
	public Sprite knockout; // cellBlockKnockout; stairwellKnockout;
	public Sprite stairwell;
	public Sprite barrack;
	
	private enum States {
		Introduction, 
		Cell, CellDoor, CellPlate, CellBed, CellWindow,
		CellMate, CellMateTalk, CellMateYes, CellMateNo, CellMateIgnore,
		Cellblock, CellblockKnockout,
		Stairwell, StairwellKnockout,
		Barrack
	};
	
	private States myState;
	private int fork;
	private int mate;
	private int clothes;
	
	// Use this for initialization.
	void Start() {
		title.sprite = splash;
		myState = States.Introduction;
	}
	
	// Update is called once per frame.
	void Update() {
		print (myState);
		if 		(myState == States.Introduction)      {action.sprite = cell;       zone.text = "Cell";      Introduction();}
		else if (myState == States.Cell)              {action.sprite = cell;       zone.text = "Cell";      Cell();}
		else if (myState == States.CellDoor)          {action.sprite = cellDoor;   zone.text = "Cell";      CellDoor();}
		else if (myState == States.CellPlate)         {action.sprite = cellPlate;  zone.text = "Cell";      CellPlate();}
		else if (myState == States.CellBed)           {action.sprite = cellBed;    zone.text = "Cell";      CellBed();}
		else if (myState == States.CellWindow)        {action.sprite = cellWindow; zone.text = "Cell";      CellWindow();}
		else if (myState == States.CellMate)          {action.sprite = cellMate;   zone.text = "Cellblock"; CellMate();}
		else if (myState == States.CellMateTalk)      {action.sprite = cellMate;   zone.text = "Cellblock"; CellMateTalk();}
		else if (myState == States.CellMateYes)       {action.sprite = cellMate;   zone.text = "Cellblock"; CellMateYes();}
		else if (myState == States.CellMateNo)        {action.sprite = cellMate;   zone.text = "Cellblock"; CellMateNo();}
		else if (myState == States.CellMateIgnore)    {action.sprite = cellBlock;  zone.text = "Cellblock"; CellMateIgnore();}
		else if (myState == States.Cellblock)         {action.sprite = cellBlock;  zone.text = "Cellblock"; Cellblock();}
		else if (myState == States.CellblockKnockout) {action.sprite = knockout;   zone.text = "Cellblock"; CellblockKnockout();}
		else if (myState == States.Stairwell)         {action.sprite = stairwell;  zone.text = "Stairwell"; Stairwell();}
		else if (myState == States.StairwellKnockout) {action.sprite = knockout;   zone.text = "Stairwell"; StairwellKnockout();}
		else if (myState == States.Barrack)           {action.sprite = barrack;    zone.text = "Barrack";   Barrack();}
	}
	
	#region State cell handlers.
	void Introduction() {
		fork = 0;
		mate = 0;
		clothes = 0;
		
		script.text = "You’re stuck in prison because you’ve committed murder. " +
					  "Find a way to escape this prison without getting caught " +
					  "by the guards.\n\n" +
					  "Press [C] to Continue.";
		
		if (Input.GetKeyDown(KeyCode.C)) {myState = States.Cell;}
	}
	
	void Cell() {
		script.text = "Look around your cell to figure out how to unlock the rusty " +
					  "barred door.\n\n" + 
					  "Press [D] to inspect Door, press [P] to inspect dirty Plate " +
					  "with last night’s meal, press [B] to inspect your " +
					  "uncomfortable Bed, or press [W] to inspect the Window that " +
					  "peers into the starry night.";
		
		if      (Input.GetKeyDown(KeyCode.D)) {myState = States.CellDoor;}
		else if (Input.GetKeyDown(KeyCode.P)) {myState = States.CellPlate;}
		else if (Input.GetKeyDown(KeyCode.B)) {myState = States.CellBed;}
		else if (Input.GetKeyDown(KeyCode.W)) {myState = States.CellWindow;}
	}
	
	void CellDoor() {
		if (fork == 1) {
			script.text = "The rusty barred door is locked.\n\n" +
						  "Press [P] to Pick the lock or press [R] to Return to " +
						  "searching your cell.";
			
			if      (Input.GetKeyDown(KeyCode.P)) {myState = States.CellMate;}
			else if (Input.GetKeyDown(KeyCode.R)) {myState = States.Cell;}
		} else {
			script.text = "The rusty barred door is locked.\n\n" +
						  "Press [R] to Return to searching your cell.";
			
			if (Input.GetKeyDown(KeyCode.R)) {myState = States.Cell;}	
		}
	}
	
	void CellPlate() {
		if (fork < 1) {
			script.text = "Oh look, a nice steel Fork to craft into a lock pick.\n\n" +
						  "Press [T] to Take the fork or press [R] to Return to " +
						  "searching your cell.";
			
			if      (Input.GetKeyDown(KeyCode.T)) {fork = 1; myState = States.Cell;}
			else if (Input.GetKeyDown(KeyCode.R)) {myState = States.Cell;}
		} else {
			script.text = "Nothing left on this plate.\n\n" +
				          "Press [R] to Return to searching your cell.";
			
			if (Input.GetKeyDown(KeyCode.R)) {myState = States.Cell;}
		}
	}
	
	void CellBed() {
		script.text = "You don’t want to sleep here again. Perhaps, the linen sheet " +
					  "may offer a quick escape? But there’s nothing high enough to " +
					  "tie this sheet to.\n\n" +
					  "Press [R] to Return to searching your cell.";
		
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.Cell;}
	}
	
	void CellWindow() {
		script.text = "…\n\n" +
					  "Press [R] to Return to searching your cell.";
		
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.Cell;}
	}
	#endregion
	
	#region State cellmate handlers.
	void CellMate() {
		script.text = "(Whisper) Pssss! Over here!\n\n" +
					  "Press [T] to talk to your next-door cellmate or " +
					  "press [I] to Ignore him.";
		
		if      (Input.GetKeyDown(KeyCode.T)) {myState = States.CellMateTalk;}
		else if (Input.GetKeyDown(KeyCode.I)) {myState = States.CellMateIgnore;}
	}
	
	void CellMateTalk() {
		script.text = "Please, get me out of here! They’re going to execute me at the crack of dawn.\n\n" +
					  "Press [Y] to say “Yes, I’ll get you out.” or press [N] to say “No, you will die.”";
		
		if      (Input.GetKeyDown(KeyCode.Y)) {myState = States.CellMateYes;} 
		else if (Input.GetKeyDown(KeyCode.N)) {myState = States.CellMateNo;}
	}
	
	void CellMateYes() {
		script.text = "Press [P] to Pick your cellmate’s door lock or press [K] to Kill him with the fork.";
		
		if      (Input.GetKeyDown(KeyCode.P)) {mate = 1; myState = States.Cellblock;} 
		else if (Input.GetKeyDown(KeyCode.K)) {myState = States.Cellblock;}
	}
	
	void CellMateNo() {
		script.text = "Your Cellmate grabs you by the neck and twists it.\n\n" +
					  "Press [R] to Restart the game.";
		
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.Introduction;} 
	}
	
	void CellMateIgnore() {
		script.text = "GUARDS AN ESCAPPEE!\n\n" +
					  "Press [R] to Restart the game.";
		
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.Introduction;} 
	}
	#endregion
	
	#region State cellblock handlers.
	void Cellblock() {
		script.text = "The guard up ahead is walking towards the stairwell.\n\n" +
					  "Press [S] to Sneak past the guard or press [K] to " +
					  "Knockout the guard unconscious.";
		
		if      (Input.GetKeyDown(KeyCode.S)) {myState = States.Stairwell;}
		else if (Input.GetKeyDown(KeyCode.K)) {myState = States.CellblockKnockout;} 
	}
	
	void CellblockKnockout() {
		script.text = "You hit the guard upside the head.\n\n" +
					  "Press [T] to Take the guard’s clothes or " +
					  "press [W] to walk towards the stairwell.";
		
		if      (Input.GetKeyDown(KeyCode.T)) {clothes++; myState = States.Stairwell;}
		else if (Input.GetKeyDown(KeyCode.W)) {myState = States.Stairwell;} 
	}
	#endregion
	
	#region State stairwell handlers.
	void Stairwell() {
		script.text = "The guard in the stairwell paces back and forth between four flights " +
					  "of steps. You know at the top of the stairwell is a door that leads " +
					  "into the barrack.\n\n" +
					  "Press [S] to Sneak past the guard or press [K] to Knockout the guard " +
					  "unconscious.";
		
		if      (Input.GetKeyDown(KeyCode.S)) {myState = States.Barrack;}
		else if (Input.GetKeyDown(KeyCode.K)) {myState = States.StairwellKnockout;} 
	}
	
	void StairwellKnockout() {
		if (clothes < 1) {
			script.text = "You hit the guard upside the head.\n\n" +
						  "Press [T] to Take the guard’s clothes or " +
						  "press [W] to walk towards the barrack.";
		
			if      (Input.GetKeyDown(KeyCode.T)) {clothes++; myState = States.Barrack;}
			else if (Input.GetKeyDown(KeyCode.W)) {myState = States.Barrack;}
		} else {
			script.text = "You hit the guard upside the head.\n\n" +
						  "Press [W] to walk towards the barrack.";
			
			if (Input.GetKeyDown(KeyCode.W)) {myState = States.Barrack;}
		}
	}
	#endregion
	
	#region State barrack handler.
	void Barrack() {
		if (mate == 1 && clothes > 0) {
			script.text = "The guards in the barrack don’t notice you, but are little confused on " +
						  "why your cellmate is being brought up earlier than his appointed " +
						  "execution. You say that you’ll handle his death as he was trying to " +
						  "escape. Then, you walk your cellmate to the outside, where the gallows " +
						  "hang. You release him and you both start to run into the busy city.\n\n" +
						  "Press [R] to Replay the game.";
			
			if (Input.GetKeyDown(KeyCode.R)) {myState = States.Introduction;}
		} else if (mate == 1 && clothes < 1) {
			script.text = "The guards in the barrack notice your cellmate and you are both " + 
						"escapees and they quickly rush at you two with swords in hand.\n\n" +
						"Press [R] to Restart the game.";
			
			if (Input.GetKeyDown(KeyCode.R)) {myState = States.Introduction;}
		} else if (clothes > 0) {
			script.text = "The guards in the barrack don’t notice you and you calmly walk " +
						  "through the barrack and out the front door into the city.\n\n" +
						  "Press [R] to Replay the game.";
			
			if (Input.GetKeyDown(KeyCode.R)) {myState = States.Introduction;}
		} else {
			script.text = "The guards in the barrack notice you’re an escapee and they " +
						  "quickly rush at you with swords in hand.\n\n" +
						  "Press [R] to Restart the game.";
			
			if (Input.GetKeyDown(KeyCode.R)) {myState = States.Introduction;}
		}
	}
	#endregion
}
