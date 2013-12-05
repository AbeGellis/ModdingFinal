using UnityEngine;
using System.Collections;

public class ColorArea : MonoBehaviour {

	//Available colors in the game
	public enum CharColor { Red = 0, Green, Blue, None}; // Orange, Yellow, Purple, None };
	//Corresponding color objects
	static Color[] CharPallete = new Color[4] {Color.red, Color.green, Color.blue, Color.white};
		//new Color(1f, .5f, 0f), Color.yellow, new Color(1f, 0f, 1f), Color.white};

	public CharColor color;

	public static Color GetPallete(CharColor c) {
		return CharPallete[(int) c];
	}

	public static CharColor RandomColor() {
		int r = Random.Range(0, 3);
		return (CharColor) r;
	}

	void OnCollisionEnter(Collision collision) {
		CharacterControl character = collision.gameObject.GetComponent<CharacterControl>();

		if (character != null) {
			character.TouchColorArea(color);
		}
	}

	void Start () {
		particleSystem.startColor = GetPallete(color);
		light.color = Color.Lerp(GetPallete(color), Color.white, .5f);
	}
	
	void Update () {
	}
}
