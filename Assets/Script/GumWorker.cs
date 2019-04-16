using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GumWorker : MonoBehaviour {

	public int Worker_Num;
	public AudioSource Upgrade_Sound;
	public Text Hiring_Fee_Text;
	bool isOK;
	public UpdateSkill2Data Skill2;

    public int Get_Worke_Num
    {
		get
		{
			//Some other code
            return Worker_Num;
		}
    }

	public int Next_Hiring_Fee;
	public float Gum_Generate_Speed;
	float timer_f;
	// Use this for initialization
	void Start () {
		Upgrade_Sound.Stop ();
		Worker_Num = 0;
		Next_Hiring_Fee = 52;
		Gum_Generate_Speed = 3.3f;
	}	
	// Update is called once per frame
	void Update () {
		timer_f += Time.deltaTime;
		if (timer_f >= Gum_Generate_Speed) {
			GlobelData.Instance.Cur_Gum++;
			timer_f = 0f;
		}

		if (Skill2.Skill2_Running && !isOK) {
			Gum_Generate_Speed /= 2 * Mathf.Pow (1.01f, GlobelData.Instance.Skill2Level);
			Gum_Generate_Speed = Mathf.Round(Gum_Generate_Speed*100)/100f;
			isOK = true;
		} 
		else if(!Skill2.Skill2_Running && isOK) {
			Gum_Generate_Speed = 3f*Mathf.Pow(0.8f,Worker_Num)+0.3f;   //取到小數點後兩位;
			Gum_Generate_Speed = Mathf.Round(Gum_Generate_Speed*100)/100f;
			isOK = false;
		}
	}

    internal string GetWorker_Num()
    {
        
        throw new NotImplementedException();
    }

    public void Hire_Worker(){
		if (GlobelData.Instance.Gold >= Next_Hiring_Fee) {
			Upgrade_Sound.Play ();
			Worker_Num++;
			GlobelData.Instance.Gold -= Next_Hiring_Fee;

			Next_Hiring_Fee = (int)(10 + 20 * Mathf.Pow(1.1f,(Worker_Num+1))+ (Worker_Num+1) * 20);
			Hiring_Fee_Text.text = "" + Next_Hiring_Fee;
			Gum_Generate_Speed = 3f*Mathf.Pow(0.8f,Worker_Num)+0.3f;   //取到小數點後兩位;
			Gum_Generate_Speed = Mathf.Round(Gum_Generate_Speed*100)/100f;

		} 
		else {
			Debug.Log ("錢不夠!");
		}
	}
}
