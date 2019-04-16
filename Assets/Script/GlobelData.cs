using UnityEngine;

public class GlobelData : MonoBehaviour
{

	public static GlobelData Instance;

	private int _hp = 2017;
	private int _gold = 800;
	private int _GumCount = 50;

	public int Gold
	{
		get
		{
			return _gold;
		}
		set
		{
			_gold = value;
			//TODO value set to gold UI
			ChangeGoldText.Instance.SetGold(value);
		}
	}

	public int Cur_Gum
	{
		get
		{
			return _GumCount;
		}
		set
		{
			_GumCount = value;
			ChangeGumText.Instance.SetGum(value);
		}
	}
	public int Hp
	{
		get
		{
			return _hp;
		}
		set
		{

			ControlBoold.Instance.ToHp(value);
			_hp = value;
		}
	}
	public int Score;

	//Skill
	public int Skill1Level = 1;
	public int Skill2Level = 1;
	public int Skill3Level = 1;
	public float Skill1CD;
	public float Skill2CD;
	public float Skill3CD;

	private void Awake()
	{
		Instance = this;
	}
}
