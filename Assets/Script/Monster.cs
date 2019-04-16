using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG;
using System;

public class Monster : MonoBehaviour
{
	public int Uid;
	public int Id;
	public float MoveTime;
	public int HpBase = 95;
	public int Hp = 95;
	public int Atk = 20;
	public int Gold = 10;

	public void Run(float delayTime = 0f)
	{
		transform.DOMove(new Vector3(-14.9f, transform.position.y, 0f), MoveTime)
			.SetDelay(delayTime)
			.SetEase(Ease.Linear);
	}

	public void Update()
	{
		if (transform.position.x < -6f)
		{
			EventSystem.OnMonsterTouchHome(this);
		}
	}
}
