using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGoldText : MonoBehaviour {

	public static ChangeGoldText Instance;

	public Text GoldText;

	public void UpdateText(string text)
	{
		GoldText.text = text;
	}

	public void SetGold(int gold)
	{
		GoldText.text = "" + GlobelData.Instance.Gold;
	}

	private void Awake()
	{
		Instance = this;
	}
}
