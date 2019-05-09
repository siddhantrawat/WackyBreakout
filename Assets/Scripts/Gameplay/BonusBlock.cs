using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block {

	// Use this for initialization
	override protected void Start ()
    {
        base.Start();
		bonusBlockPoints = ConfigurationUtils.BonusBlockPoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
