using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperCommand : MonoBehaviour {

	public GameObject Bullet;
	public GameObject Monster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Z)) {
			GlobelData.Instance.Cur_Gum+=3;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
