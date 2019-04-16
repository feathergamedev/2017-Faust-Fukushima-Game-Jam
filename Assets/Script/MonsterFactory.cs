using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[Serializable]
public class MonsterData
{
	public int Id;
	public Monster Monster;
}

public class MonsterFactory : MonoBehaviour
{
	public List<MonsterData> MonsterResource;

	private static MonsterFactory _instance;

	public static MonsterFactory Instance
	{
		get
		{
			return _instance;
		}
	}

	public Monster NewMonster(int Id, int waveIndex)
	{
		return NewMonster(Id, Vector3.zero, waveIndex);
	}

	public Monster NewMonster(int Id, Vector3 position, int waveIndex)
	{
		Monster clone = MonsterResource.FirstOrDefault(p => p.Id == Id).Monster;

		if (clone == null)
		{
			Debug.LogErrorFormat("[MonsterFactory] Not Found Monster Id {0}", Id);
		}

		Monster newMob = Instantiate(clone, position, transform.rotation);
		newMob.Hp = (int)(clone.HpBase * Math.Pow(1.01, waveIndex) + waveIndex * Math.Pow(waveIndex, 1.05));
		newMob.Gold = 10 + waveIndex * 2 * UnityEngine.Random.Range(0, 2);
		newMob.Uid = UidCreater.New();

		return newMob;
	}

	[ContextMenu("TEST")]
	private void Test()
	{
		NewMonster(100, 0);
	}

	private void Awake()
	{
		_instance = this;
	}
}
