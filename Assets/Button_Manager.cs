﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Replay(){
		Application.LoadLevel (Application.loadedLevel);

	}

	public void Quit(){
		Application.Quit ();
	}
}
