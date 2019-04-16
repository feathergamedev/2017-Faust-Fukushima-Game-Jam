using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperBackend : MonoBehaviour {

	public GumWorker worker;

	public Text Worker_UI;
	public Button Worker_Button;
	public Text Next_Fee_UI;
	public Text Gold_UI;
	public Text Gum_Generate_Speed_UI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Gold_UI.text = "Gold:" + GlobelData.Instance.Gold;
        Worker_UI.text = "工人數:" + worker.Worker_Num;
		Next_Fee_UI.text = "Next Fee:" + worker.Next_Hiring_Fee;
		Gum_Generate_Speed_UI.text = "Speed:" + worker.Gum_Generate_Speed + "秒/顆";

		if (Input.GetKeyDown (KeyCode.G)) {
			GlobelData.Instance.Gold += 500;
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			worker.Hire_Worker ();
		}
	}

	public void Add_Gold(){
		GlobelData.Instance.Gold += 500;
	}
}
