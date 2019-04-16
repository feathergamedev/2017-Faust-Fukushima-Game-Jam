using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSkill3Data : MonoBehaviour {

	public int LevelUpNeedMoney;

	public Text NeedMoneyText;

	public float ColdTime;
	private float Coldtimer = 0;
	public Image fillImage;
	private bool IsStartCD;
	public AudioSource Skill_Sound, UpGrade_Sound;

	public Image StillImage;
	private int SkillStatus = 0;
	public float StillTime;
	private float Stilltimer = 0;

	public bool Skill3_Running;

	// Update is called once per frame
	void Update () {

		if (SkillStatus == 1) 
		{
			Skill3_Running = true;
			Stilltimer += Time.deltaTime;
			StillImage.fillAmount = Stilltimer / StillTime;
		}

		if (Stilltimer >= StillTime) 
		{
			Skill3_Running = false;
			StillImage.fillAmount = 0;
			Stilltimer = 0;
			SkillStatus = 2;
			IsStartCD = true;
		}


		if (IsStartCD) 
		{
			Coldtimer += Time.deltaTime;
			fillImage.fillAmount = (ColdTime - Coldtimer) / ColdTime;
		}

		if (Coldtimer >= ColdTime) 
		{
			fillImage.fillAmount = 0;
			Coldtimer = 0;
			IsStartCD = false;
			SkillStatus = 0;
		}
	}

	public void OnCD()
	{
		if (SkillStatus == 0) 
		{
			Skill_Sound.Play ();
			SkillStatus = 1;
		}
	}

	// Use this for initialization
	void Start () {
		CountLevelUpNeedMoney ();
		NeedMoneyText.text = LevelUpNeedMoney.ToString();
		CountCDTime ();
		CountStillTime ();
	}

	public void LevelUp()
	{
		if (GlobelData.Instance.Gold < LevelUpNeedMoney) 
			return;

		UpGrade_Sound.Play ();
		GlobelData.Instance.Gold -= LevelUpNeedMoney;
		GlobelData.Instance.Skill3Level++;
		CountLevelUpNeedMoney ();
		CountCDTime ();
		CountStillTime ();
		NeedMoneyText.text = LevelUpNeedMoney.ToString();
	}

	private void CountCDTime()
	{
		ColdTime = 60 * Mathf.Pow (0.98f, (float)GlobelData.Instance.Skill3Level);
	}

	private void CountLevelUpNeedMoney()
	{
		LevelUpNeedMoney = (int)(10 * Mathf.Pow (1.05f, (float)GlobelData.Instance.Skill3Level) + GlobelData.Instance.Skill3Level * 300 + 1);
	}

	private void CountStillTime()
	{
		StillTime = 10 + 5 * Mathf.Pow (1.01f , (float)GlobelData.Instance.Skill3Level);
	}
}
