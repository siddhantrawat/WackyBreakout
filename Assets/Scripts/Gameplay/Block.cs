using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Block : MonoBehaviour {

	protected float standardBlockPoints;
	protected float bonusBlockPoints;
	protected float pickUpBlockPoints;
    PointsAddedEvent pointsAddedEvent = new PointsAddedEvent();
    BlockDestroyedEvent blockDestroyEvent = new BlockDestroyedEvent();

    // Use this for initialization
    virtual protected void Start () {
        EventManager.AddUpdateScoreInvoker(this);
        EventManager.AddBlockDestroyInvoker(this);
	}
	
	// Update is called once per frame
	void Update () {
       
         
    }

	virtual protected void OnCollisionEnter2D()
	{

        if (gameObject.CompareTag("StandardBlock"))
        {
            pointsAddedEvent.Invoke((int)standardBlockPoints);
            AudioManager.Play(AudioClipName.Standard);
        }
  
        else if (gameObject.CompareTag("BonusBlock"))
        {
            AudioManager.Play(AudioClipName.Bonus);
            pointsAddedEvent.Invoke((int)bonusBlockPoints);
        }
        
        else if  (gameObject.CompareTag("PickUpBlock"))
        {
            pointsAddedEvent.Invoke((int)pickUpBlockPoints);
        }
        Destroy (gameObject);
            blockDestroyEvent.Invoke();

    }

    public void AddUpdateScoreListener(UnityAction<int> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }

    public void AddBlockDestroyListener(UnityAction listener)
    {
        blockDestroyEvent.AddListener(listener);
    }
}
    