using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlBoold : MonoBehaviour {

	public static ControlBoold Instance;

	public Slider HPStrip;
	public int HP;
	private int LastHP;

	[SerializeField]
	private Image BloodImage;


    public GameObject tower;
    public GameObject brokenTower;
    bool towerDestroy = false;
	// Use this for initialization
	void Start () {
		HPStrip.maxValue = HP;
		LastHP = HP;
		BloodImage.GetComponent<Image>().color = new Color32 (0, 255, 0, 255);
	}

	public void ToHp(int hp)
	{
		LastHP = hp;
	}
		
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKeyDown("p"))
        {
            LastHP =0;
        }

        HPStrip.value = HP;


		if (LastHP != HP) 
		{
			HP = (int)Mathf.Lerp(HP, LastHP, 0.1f);
		}

        if (LastHP <= 0 && towerDestroy==false)
        {
			GameObject brtw = Instantiate(brokenTower, tower.transform.position+Vector3.up*2, Quaternion.identity);
            towerDestroy = true;
            Destroy(tower);
        }
    }

	private void Awake()
	{
		Instance = this;
	}
}
