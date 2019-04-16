using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSkill1Data : MonoBehaviour {

	public int LevelUpNeedMoney;
	public AudioSource Skill_Sound, UpGrade_Sound;

	public Text NeedMoneyText;

	public float ColdTime;
	private float timer = 0;
	public Image fillImage;
	private bool IsStartCD;

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

	public void OnCD()
	{
		Skill_Sound.Play ();
		IsStartCD = true;
	}

	// Use this for initialization
	void Start () {
		CountLevelUpNeedMoney ();
		NeedMoneyText.text = LevelUpNeedMoney.ToString();
		CountCDTime ();
	}

	public void LevelUp()
	{
		if (GlobelData.Instance.Gold < LevelUpNeedMoney) 
			return;

		UpGrade_Sound.Play ();
		GlobelData.Instance.Gold -= LevelUpNeedMoney;
		GlobelData.Instance.Skill1Level++;
		CountLevelUpNeedMoney ();
		CountCDTime ();
		NeedMoneyText.text = LevelUpNeedMoney.ToString();
	}

	private void CountCDTime()
	{
		ColdTime = 20 * Mathf.Pow (0.99f, (float)GlobelData.Instance.Skill1Level);
	}

	private void CountLevelUpNeedMoney()
	{
		LevelUpNeedMoney = (int)(50 * Mathf.Pow (1.05f, (float)GlobelData.Instance.Skill1Level) + GlobelData.Instance.Skill1Level * 5 + 1);
	}
}
