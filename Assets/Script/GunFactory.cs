using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
				
public class GunFactory : MonoBehaviour {

	public List<Gun> Resource;

	private static GunFactory _instance;

	public static GunFactory Instance
	{
		get
		{
			return _instance;
		}
	}

	public Gun New(int Id)
	{
		return New(Id, Vector3.zero);
	}

	public Gun New(int Id, Vector3 position)
	{
		Gun resource = Resource.First(p => p.Data.Id == Id);

		Gun clone = Instantiate(resource, position, transform.rotation);
		clone.Data = resource.Data;
		clone.Data.Uid = UidCreater.New();

		return clone;
	}

	[ContextMenu("TEST")]
	private void Test()
	{
		New(0);
	}

	private void Awake()
	{
		_instance = this;
	}
}
