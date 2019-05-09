using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelBuilder : MonoBehaviour {
	[SerializeField]
	GameObject prefabBall;

	[SerializeField]
	GameObject prefabPaddle;

	[SerializeField]
	GameObject[] prefabBlock = new GameObject[3]; // 0 for standard , 1 for bonus, 2 for pickup

	System.Random rand = new System.Random();
	// Use this for initialization
	void Start () {
	    Instantiate<GameObject> (prefabBall);

		Instantiate<GameObject> (prefabPaddle);

		PlaceBlock ();


	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			MenuManager.GoToMenu (MenuName.Pause);

		}
	}

	void PlaceBlock()
	{
		GameObject tempBlock =  Instantiate<GameObject>(prefabBlock[0]);
		BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
		float blockColliderWidth = collider.size.x;
		float blockColliderHeight = collider.size.y;
		Destroy (tempBlock);
		Vector3 position;

		// y position is 1/5 times the size of screen

		position = new Vector3(ScreenUtils.ScreenLeft + blockColliderWidth, 
			ScreenUtils.ScreenTop - (1f/5)*(Mathf.Abs(ScreenUtils.ScreenTop)+Mathf.Abs(ScreenUtils.ScreenBottom)),0);

		for (int i =1;i<=3;i++)
		{
			//while for building single row

		while (position.x < ScreenUtils.ScreenRight - blockColliderWidth/2) {

				//calculate which block to spawn
				float prob = (float)rand.NextDouble();

				int n;
				if (prob <= .5f)
					n = 0;
				else if (prob <= .83f)
					n = 1;
				else
					n = 2;


				GameObject b= Instantiate<GameObject> (prefabBlock[n], position, Quaternion.identity);
				position.x = position.x + blockColliderWidth + blockColliderHeight;

				if(n==2)  //to get both effects around 8% times
				{
					if(prob <.92f)
						b.GetComponent<PickUpBlock> ().Effect = PickupEffect.Speedup;
					else
						b.GetComponent<PickUpBlock> ().Effect = PickupEffect.Freezer;

				}
				}
			position.x = ScreenUtils.ScreenLeft + blockColliderWidth;
			position.y = position.y - 3f/2* blockColliderHeight;

		}
	}

}
