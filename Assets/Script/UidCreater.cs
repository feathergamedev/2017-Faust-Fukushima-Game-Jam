using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UidCreater
{
	private static int Uid;

	public static int New()
	{
		Uid = Uid + 1;
		return Uid;
	}
}
