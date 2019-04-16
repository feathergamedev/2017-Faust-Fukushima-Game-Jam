using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public struct GunData
{
	public int Uid;
	public int Id;
	public Gun Gun;
	public float Speed;
}

public class Gun : MonoBehaviour
{
	float Destroy_Timer;

	public static string GunTag = "Gun";

	public GunData Data;

	public Vector3 TestTarget;

	public void Shoot(Vector3 targetPosition)
	{
		float dictance = Vector3.Distance(transform.position, targetPosition);

		transform.DOMove(targetPosition, dictance / Data.Speed).SetEase(Ease.Linear);
	}

	[ContextMenu("TEST")]
	private void TestMoveToTarget()
	{
		Shoot(TestTarget);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other == null)
		{
			return;
		}

		if (other.tag == "Monster")
		{
			Monster m = other.GetComponent<Monster>();
			EventSystem.OnGunTouchMonster(this, m);
		}
	}

	public void Clear()
	{

	}

	private void Awake()
	{
		Data.Gun = this;
	}

	void Start(){
		Destroy_Timer = 0f;
	}

	void Update(){
		if (this.gameObject.name == "Gun0" || this.gameObject.name == "Gun1") 
			return;		
		

		Destroy_Timer += Time.deltaTime;

		if (Destroy_Timer >= 1.5f) {
			Destroy (this.gameObject);
		}
	}
}
