using UnityEngine;
using System.Collections;

public class GUIComponent : MonoBehaviour
{
	public GUISkin guiSkin; // choose a guiStyle (Important!)

	public string text = "Will"; // choose your name

	public Color color = Color.white;   // choose font color/size
	public float fontSize = 12;
	public float offsetX = 0;
	public float offsetY = 0.5f;

	float boxW = 150f;
	float boxH = 20f;

	public bool messagePermanent = true;

	public float messageDuration { get; set; }

	Vector2 boxPosition;
	void Start()
	{
		if(messagePermanent)
		{
			messageDuration = 1;
		}
	}
	void OnGUI()
	{
		if(messageDuration > 0)
		{
			if(!messagePermanent) // if you set this to false, you can simply use this script as a popup messenger, just set messageDuration to a value above 0
			{
				messageDuration -= Time.deltaTime;
			}

			GUI.skin = guiSkin;
			boxPosition = Camera.main.WorldToScreenPoint(transform.position);
			boxPosition.y = Screen.height - boxPosition.y;
			boxPosition.x -= boxW * 0.1f;
			boxPosition.y -= boxH * 1.0f;
			guiSkin.box.fontSize = 10;

			GUI.contentColor = color;

			Vector2 content = guiSkin.box.CalcSize(new GUIContent(text));

//			GUI.Box(new Rect(boxPosition.x - 10, boxPosition.y + 10, content.x, content.y), text);
			GUI.Box(new Rect((boxPosition.x - content.x / 2 * offsetX) + 3, boxPosition.y + offsetY - 30, content.x, content.y), text);

		}
	}
}