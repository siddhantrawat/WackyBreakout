using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpBlock : Block {
	[SerializeField]
	Sprite[] sprites = new Sprite[2];

	PickupEffect effect;

	int freezerEffectDuration;
	int speedupEffectDuration;
	int speedupFactor;
	FreezerEffectActivated freezerEffectActivated = new FreezerEffectActivated ();
	SpeedEffectActivated speedEffectActivated = new SpeedEffectActivated();


	// Use this for initialization

	public PickupEffect Effect
	{
		set{
			effect = value;
			if (value == PickupEffect.Speedup) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [1];
				speedupEffectDuration = ConfigurationUtils.SpeedupEffectDuration;
				speedupFactor = ConfigurationUtils.SpeedupFactor;
			}
			else if (value == PickupEffect.Freezer) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [0];
				freezerEffectDuration = ConfigurationUtils.FreezerEffectDuration;
				}
		}
	}

	protected override void Start () {
        base.Start();
		pickUpBlockPoints = ConfigurationUtils.PickUpBlockPoints;

		EventManager.AddInvoker (this);
	}

	protected override void OnCollisionEnter2D ()
	{
		base.OnCollisionEnter2D ();
		if (effect == PickupEffect.Freezer) {
            AudioManager.Play(AudioClipName.Freeze);
            freezerEffectActivated.Invoke (freezerEffectDuration);
			
		} else if (effect == PickupEffect.Speedup)
		{
            AudioManager.Play(AudioClipName.SpeedUp);
            speedEffectActivated.Invoke (speedupEffectDuration, speedupFactor);
		}
	}

	public void AddListenerToFreezer(UnityAction<int> listener)
	{
		
		freezerEffectActivated.AddListener (listener);

	}

	public void AddListenerToSpeed(UnityAction<int,int> listener)
	{
		speedEffectActivated.AddListener (listener);
	}

}