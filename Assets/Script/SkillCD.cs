using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCD : MonoBehaviour {

	public float ColdTime = 2;
	private float timer = 0;
	private Image fillImage;
	private bool IsStartCD;


	// Use this for initialization
	void Start () {
		fillImage = this.GetComponent<UnityEngine.UI.Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsStartCD) 
		{
			timer += Time.deltaTime;
			fillImage.fillAmount = (ColdTime - timer) / ColdTime;
		}

		if (timer >= ColdTime) 
		{
			fillImage.fillAmount = 0;
			timer = 0;
			IsStartCD = false;
		}
	}

	public void OnClick()
	{
		IsStartCD = true;
	}
}
