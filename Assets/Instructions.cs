using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {

	/*How to create a level and expanding existing codebase easily.
	 * 1) Duplicate any of the existing scenes in Scenes folder.
	 * 2) All level objects should be under Environment parent gameobject. Duplicate existing prefabs like crash walls, bombs, obstacles etc to design level.
	 * 3) To expand and create newer color screens for breakers, make changes in Cube properties and add new colors in the if statements similar to the existing ones.
	 * 4) In Camera Pivot, add one more case in switch for pressing of 1 button for more colors.
	 * 5) Also in Cube Properties, add the materials for the newer colors as prefabs.
	 * 6) Very similar to the extra parts if you want to add. Changes to be made in Cube Properties add more if statements.
	 * 7) Also Command F in Camera Pivot aand wherever "rocket" or "cement" is used, add extra case for newer part. Of course, attach Breaker Script to EVERY part on ship EXCEPT cockpit.
	 * */
}
