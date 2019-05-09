using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils {


	static SpeedupEffectMonitor util;


	public static bool isActive
	{
		get{ return util.active;}
	}

	public static int SpeedupFactor
	{
		get{ return util.SpeedupFactor;}
	}


	public static float RemainingTime
	{
		get{ return util.TimeRemaining;}
	}


	// Use this for initialization

	public static void Initialize () {
		util = Camera.main.GetComponent<SpeedupEffectMonitor>();
	}

}
