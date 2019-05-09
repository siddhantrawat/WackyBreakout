using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour {
	Timer timer;
	int speedupFactor;

	public int SpeedupFactor
	{
		get{ return speedupFactor; }
	}

	public bool active
	{
		get{
			if (timer.Running)
				return true;
			else
				return false;
		}
	}

	public float TimeRemaining
	{
		get{ 
			if (timer.Running)
				return(timer.CurrentDuration - timer.ElapsedSeconds);
			else if (timer.Finished)
				return 0;
			else
				return -1;
		}
	}

	void Start () {
		timer = gameObject.AddComponent<Timer> ();	
		EventManager.AddListersToSpeed (startTimer);
	}
	
	// Update is called once per frame
	void startTimer ( int duration, int factor) {

		speedupFactor = factor;

		if (!timer.Running) {
			timer.Duration = duration;
			timer.Run ();
		} 
		else
			timer.Duration = timer.CurrentDuration + duration; 	


		Debug.Log (timer.CurrentDuration);
	}
}
