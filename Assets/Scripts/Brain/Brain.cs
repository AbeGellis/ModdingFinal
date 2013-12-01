using UnityEngine;
using System.Collections;

//Controls a character - make child classes to make new AI patterns
//To implement a brain, create a prefab with only that script attached (if none exists)
//Transform controls look direction
public class Brain : MonoBehaviour {
	
	//Body this is attached to
	protected CharacterControl body;

	//Current color
	public ColorArea.CharColor color;

	//Shows color
	public bool colorVisible = true;

	//How many points you get when it dies
	public int pointsWorth = 0;

	//Mutator for color
	public void setColor(ColorArea.CharColor color) {
		if (this.color != color) {
			this.color = color;
			body.renderer.material.color = ColorArea.GetPallete(color);
		}
	}

	void Start() {
		body.renderer.material.color = ColorArea.GetPallete(color);	//Initial tint
	}

	//Matches it to the body
	virtual public void Assign(CharacterControl body) {
		this.body = body;
	}

	virtual public void Kill() {
		ScoreControl.score += pointsWorth;
		Destroy(this.body.gameObject);
	}
	
	//Turns both the sight and the body
	protected void Turn(Vector3 changeAngles) {
		transform.Rotate(Vector3.right, changeAngles.y);	//Vertical rotation of the sightline
		body.Turn(changeAngles);							//Tell the body to rotate
	}
	
	//Turns sight and body to look in the given direction at the given delta speed
	protected void Look(Vector3 target, float delta) {
		
		//This whole code is pretty hackish and I hope I can figure it out later
		//I could have just rotated the direction, but I wanted this to just be a wrapper for Turn()
		
		if (Vector3.Angle(target, transform.forward) < 1f)	//Doesn't bother rotating if it's basically on target
			return;
		
		target.Normalize();
		
		//Comparable horizontal/vertical vectors
		Vector3 horLook = new Vector3(transform.forward.x, 0f, transform.forward.z),
				horTarget = new Vector3(target.x, 0f, target.z),
				verLook = new Vector3(target.x, transform.forward.y, target.z),
				verTarget = new Vector3(target.x, target.y, target.z);
		
		//Angles between where you're looking and where you want to look
		float deltaX = Vector3.Angle(horLook, horTarget),
			deltaY = Vector3.Angle(verLook, verTarget);	
		
		//Because Vector3.Angle() doesn't tell you anything about the direction of the angle,
		//this figures out left/right and up/down
		if (Vector3.Cross(horLook, horTarget).y < 0)
			deltaX = -deltaX;
		if (target.y > verLook.y)
			deltaY = -deltaY;
		
		Vector3 changeAngles = new Vector3(deltaX, deltaY, 0f);
		
		//If the amount left to turn is larger than the given max speed, this reduces it to that speed
		if (changeAngles.magnitude > delta) {
			changeAngles.Normalize();
			changeAngles *= delta;
		}
		
		//Uses the calculated horizontal/vertical turns to turn
		Turn(changeAngles);
	}
	
	//Override this for update-cycle logic
	virtual public void Update () {
		//Lets you see where the character is looking
		//Debug.DrawRay(body.transform.position, transform.forward * 3f, Color.blue);
	}

	//When the body touches a colorarea
	virtual public void TouchColorArea(ColorArea.CharColor touch) {
	}

	//When the body touches another body
	virtual public void TouchCharacter(CharacterControl other) {

	}
}
