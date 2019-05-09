using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block {

	[SerializeField]
	Sprite[] standardBlock = new Sprite[3];
    // Use this for initialization
    override protected void Start () {
        base.Start();

        gameObject.GetComponent<SpriteRenderer>().sprite = standardBlock[Random.Range(0,3)];

		standardBlockPoints = ConfigurationUtils.StandardBlockPoints;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
