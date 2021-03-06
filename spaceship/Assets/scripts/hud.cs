﻿using UnityEngine;
using System.Collections;

public class hud : MonoBehaviour {

	public Texture2D crosshair;
	Rect crosshairpos;

	Rect speedpos;
    Rect scorepos;
	Movement move;
	Rigidbody rig;
	Font font;
	GUIStyle style = new GUIStyle();
	void Start () {
		crosshairpos = new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) / 2,crosshair.width,crosshair.height);
		move = GameObject.Find ("player").GetComponent("Movement") as Movement;
		rig = GameObject.Find ("player").rigidbody;

		style.fontSize = 40;
		style.normal.textColor = new Color (255, 255, 0);
		Vector2 speedsize = style.CalcSize (new GUIContent ("Speed: 100kph"));
		speedpos = new Rect (30, Screen.height - 30 - speedsize.y, speedsize.x, speedsize.y);
        Vector2 scoresize = style.CalcSize(new GUIContent("Score: 100"));
        scorepos = new Rect(100,100,100,100);
	}
	void OnGUI()
	{
		GUI.DrawTexture (crosshairpos,crosshair);

		GUI.Label(speedpos, "Speed: " +(int) rig.velocity.magnitude*10 + "kph",style);
        GUI.Label(scorepos, "Score: " + move.score,style);
	}
}
