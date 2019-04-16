using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Stayfloor : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Wall")
		{
			Debug.LogFormat("name {0}  Stay in floor", gameObject.name);
			transform.DOMove(transform.position, 0.5f);
		}
	}
}
