using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class WaveMobSetting
{
	public int TriggerWaveIndex;
	public int MobID;
}

[Serializable]
public class WaveData
{
	public int StartTime;
	public int EndTime;
}

public class MainPhase : MonoBehaviour
{
	public int AutoSettingNum = 100;

	public List<WaveMobSetting> WaveMobSetting = new List<WaveMobSetting>();
	public List<WaveData> WaveData;

	public int WaveNumBase = 5;

	public Vector3 RandPos1 = new Vector3();
	public Vector3 RandPos2 = new Vector3();

	// Use this for initialization
	void Start()
	{
		for (int waveIndex = 0; waveIndex < WaveData.Count; waveIndex++)
		{
			Debug.LogWarningFormat("WTF for www waveindex{0}", waveIndex);

			int endTime = GetWaveEndTime(waveIndex);

			int playWaveIndex = waveIndex;
			StartCoroutine(ExecuteAfterTime(endTime, () =>
			{
				EventSystem.OnWaveChange(playWaveIndex);
			}));

			WaveData w = WaveData[waveIndex];

			List<int> waveMobs = GetWaveMobs(waveIndex);

			int mobNum = GetWaveMobNum(waveIndex);

			for (int i = 0; i < mobNum; ++i)
			{
				int waveMobsIndex = UnityEngine.Random.Range(0, waveMobs.Count - 1);

				if (waveMobs.Count <= waveMobsIndex)
				{
					Debug.LogErrorFormat("[MainPhase] Load Failed waveMobsIndex {0} , waveMobsCount {1}"
						, waveMobsIndex, waveMobs.Count);
					return;
				}

				int mobId = waveMobs[waveMobsIndex];

				Monster m = MonsterFactory.Instance.NewMonster(mobId, waveIndex);
				m.transform.position = NewRandPos();
				if (m == null)
					return;

				int runDelayTime;
				if (waveIndex == 0)
				{
					runDelayTime = UnityEngine.Random.Range(0, w.EndTime);
				}
				else
				{
					runDelayTime = UnityEngine.Random.Range(w.StartTime + WaveData[waveIndex - 1].StartTime, w.EndTime + WaveData[waveIndex - 1].EndTime);
				}

				m.name = m.name + "delayTime[" + runDelayTime + "]" + "waveIndex[" + waveIndex + "]";
				m.Run(runDelayTime);
			}

			if (waveIndex % 10 == 0)
			{

			}
		}
	}

	IEnumerator ExecuteAfterTime(float time, Action Todo)
	{
		yield return new WaitForSeconds(time);

		Todo();
	}

	private List<int> GetWaveMobs(int index)
	{
		List<int> result = new List<int>();
		foreach (WaveMobSetting w in WaveMobSetting)
		{
			if (w.TriggerWaveIndex <= index + 1)
			{
				result.Add(w.MobID);
			}
		}

		return result;
	}

	private int GetWaveEndTime(int index)
	{
		int resultTime = 0;
		for (int i = 0; i < index; i++)
		{
			resultTime += WaveData[i].EndTime;

		}
		return resultTime;
	}

	private int GetWaveMobNum(int index)
	{
		if (index % 5 == 0 && index != 0)
			return (index * 3) * WaveNumBase;

		return (5 + index * 2) * WaveNumBase;

	}

	private Vector3 NewRandPos()
	{
		float randX = UnityEngine.Random.Range(RandPos1.x, RandPos2.x);
		float randY = UnityEngine.Random.Range(RandPos1.y, RandPos2.y);
		float randZ = UnityEngine.Random.Range(RandPos1.z, RandPos2.z);

		Vector3 result = new Vector3(randX, randY, -1f);

		return result;
	}

	private void Awake()
	{
		EventSystem.OnMonsterTouchHome += OnMonsterTouchHome;
	}

	private void OnMonsterTouchHome(Monster m)
	{
		if (m == null)
			return;
		
		GlobelData.Instance.Hp -= m.Atk;
		Destroy(m.gameObject);
	}

	[ContextMenu("AutoSetting")]
	private void AutoSetting()
	{
		WaveData.Clear();
		for (int i = 0; i < AutoSettingNum; i++)
		{
			WaveData.Add(new WaveData()
			{
				StartTime = i * 30,
				EndTime = (i + 1) * 30,
			});
		}
	}
}
