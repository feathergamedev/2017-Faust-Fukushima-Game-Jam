using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventSystem
{
	public static Action<int> OnWaveChange = OnWaveChangeLog;

	public static Action<Gun, Monster> OnGunTouchMonster = OnGunTouchMonsterLog;

	public static Action<Monster> OnMonsterTouchHome = OnMonsterTouchHomeLog;

	private static void OnMonsterTouchHomeLog(Monster mob)
	{

	}

	private static void OnWaveChangeLog(int waveIndex)
	{
		Debug.LogFormat("[EventSystem][ChangeWave] Index {0}", waveIndex);

	}

	private static void OnGunTouchMonsterLog(Gun gun, Monster monster)
	{

	}
}
