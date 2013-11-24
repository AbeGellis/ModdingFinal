using UnityEngine;
using System.Collections;

public class ColorArea : MonoBehaviour {

	//Available colors in the game
	public enum CharColor { Red, Green, Blue, Orange, Yellow, Purple, None };
	//Corresponding color objects
	static Color[] CharPallete = new Color[7] {Color.red, Color.green, Color.blue, 
		new Color(1f, .5f, 0f), Color.yellow, new Color(1f, 0f, 1f), Color.clear};

	public CharColor color;

	public static Color GetPallete(CharColor c) {
		return CharPallete[(int) c];
	}

	void OnCollisionEnter(Collision collision) {
		CharacterControl character = collision.gameObject.GetComponent<CharacterControl>();

		if (character != null) {
			character.TouchColorArea(color);
		}
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
}
