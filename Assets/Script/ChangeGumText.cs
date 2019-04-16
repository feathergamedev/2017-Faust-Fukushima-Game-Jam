using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGumText : MonoBehaviour {

	public static ChangeGumText Instance;

	public Text GumText;

	public void UpdateText(string text)
	{
		GumText.text = text;
	}

	public void SetGum(int gold)
	{
		GumText.text = "" + GlobelData.Instance.Cur_Gum;
	}

	private void Awake()
	{
		Instance = this;
	}
}
