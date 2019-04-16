using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TouchInput : MonoBehaviour
{
	public UpdateSkill3Data Skill3;

	public Gun gun;
	public GameObject Bullet;
	public Camera camera;
	public Vector3 TargetPos;

	public Vector3 ShootBullPos = new Vector3(-14.9f, -1f, 0f);

	public bool isOnPhone;

	private List<Gun> onFlyGun = new List<Gun>();
	private List<int> DestoryGunList = new List<int>();
	private List<int> DestoryMobList = new List<int>();

	void Start()
	{
		Input.multiTouchEnabled = true;

		EventSystem.OnGunTouchMonster += OnTouch;
	}

	private void OnTouch(Gun g, Monster m)
	{
		if (DestoryGunList.Any(p => p == g.Data.Uid))
		{
			Debug.LogFormat("Gund Touch Gun Found Same Uid {0}", g.Data.Uid);

			return;
			 
		}

		onFlyGun.Remove(g);

		GlobelData.Instance.Gold += m.Gold;

		if (!DestoryGunList.Any(p => p == g.Data.Uid))
			DestoryGunList.Add(g.Data.Uid);

		Destroy(g.gameObject);
		Destroy(m.gameObject);

	}

	// Update is called once per frame
	bool deteTouch(Vector3 pos)
	{

		return true;
	}


	void Update()
	{
		//		if (onFlyGun.Count > GlobelData.Instance.Max_Bullet)
		//			return;

		if (isOnPhone)
		{
			foreach (Touch touch in Input.touches)
			{
				if (touch.phase == TouchPhase.Ended)
				{
					if (deteTouch(touch.position) && GlobelData.Instance.Cur_Gum > 0)
					{

						Gun g = GunFactory.Instance.New(0);
						g.transform.position = gameObject.transform.position;
						g.gameObject.AddComponent<Stayfloor>();

						Vector3 newPos = new Vector3(touch.position.x, touch.position.y, g.transform.position.z);

						g.Shoot(camera.ScreenToWorldPoint(touch.position));

						onFlyGun.Add(g);

						GlobelData.Instance.Cur_Gum--;
					}
				}
			}
		}
		else
		{
			if (Skill3.Skill3_Running) 
			{
				if (Input.GetMouseButton (0)) {

					if (Input.mousePosition.y < 240f)
						return;

					Gun g = GunFactory.Instance.New (0);
					g.transform.position = gameObject.transform.position;
					g.gameObject.AddComponent<Stayfloor> ();

					var fixedPos = Input.mousePosition;
					fixedPos = new Vector3 (fixedPos.x, fixedPos.y, fixedPos.z);

					var worldPos = camera.ScreenToWorldPoint (fixedPos);

					Vector3 newPos = new Vector3 (worldPos.x, worldPos.y, transform.position.z);

					g.Shoot (newPos);
					onFlyGun.Add (g);


				}				
			} 
			else {
				
				if (Input.GetMouseButtonDown (0) && GlobelData.Instance.Cur_Gum > 0) {
					if (Input.mousePosition.y < 240f)
						return;

					Gun g = GunFactory.Instance.New (0);
					g.transform.position = gameObject.transform.position;
					g.gameObject.AddComponent<Stayfloor> ();

					var fixedPos = Input.mousePosition;
					fixedPos = new Vector3 (fixedPos.x, fixedPos.y, fixedPos.z);

					var worldPos = camera.ScreenToWorldPoint (fixedPos);

					Vector3 newPos = new Vector3 (worldPos.x, worldPos.y, transform.position.z);

					g.Shoot (newPos);
					onFlyGun.Add (g);

					GlobelData.Instance.Cur_Gum--;

				}
			}
		}
	}
}
