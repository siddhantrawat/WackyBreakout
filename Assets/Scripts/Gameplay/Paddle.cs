using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// saved for efficiency
	Rigidbody2D rb2d;
	float halfColliderWidth;
	float halfColliderHeight;

	// aiming support
	const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

	bool topCollision;
	bool freeze = false;

	float paddleMoveUnitPerSecond = 20;

	//freezer support
	Timer freezerTimer;

	// Use this for initialization

	void Start () {

		paddleMoveUnitPerSecond = ConfigurationUtils.PaddleMoveUnitsPerSecond;

		rb2d = GetComponent<Rigidbody2D>();
		BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
		halfColliderWidth = bc2d.size.x / 2;
		halfColliderHeight = bc2d.size.y / 2;

		freezerTimer = gameObject.AddComponent<Timer> ();	
		freezerTimer.Duration = 0;

		EventManager.AddListnersToFreezer (FreezePaddle);
	}

	// Update is called once per frame

	void Update()
	{
		if (freezerTimer.Running) {
			freeze = true;
	 	}
		if (freezerTimer.Finished)
			freeze = false;
	}
	void  FixedUpdate()
	{
		if (!freeze) {
		
			paddleMoveUnitPerSecond = ConfigurationUtils.PaddleMoveUnitsPerSecond;
		} 
		else
		{
			
			paddleMoveUnitPerSecond = 0;
		}   


		float horizontalInput = Input.GetAxis("Horizontal");
		if (horizontalInput != 0)
		{
			Vector2 position = rb2d.position;
			position.x += horizontalInput * paddleMoveUnitPerSecond *
				Time.deltaTime;
			position.x = CalculateClampedX(position.x);
			rb2d.MovePosition(position);

			
	}
	}
	float CalculateClampedX(float x)
	{
		// clamp left and right edges
		if (x - halfColliderWidth < ScreenUtils.ScreenLeft)
		{
			x = ScreenUtils.ScreenLeft + halfColliderWidth;
		}
		else if (x + halfColliderWidth > ScreenUtils.ScreenRight)
		{
			x = ScreenUtils.ScreenRight - halfColliderWidth;
		}
		return x;
	}	
		/// <summary>
		/// Detects collision with a ball to aim the ball
		/// </summary>
		/// <param name="coll">collision info</param>
		void OnCollisionEnter2D(Collision2D coll)
		{
			if (coll.gameObject.CompareTag("Ball") &&
				TopCollision(coll))
			{

                 AudioManager.Play(AudioClipName.PaddleHit);
                 // calculate new ball direction
                     float ballOffsetFromPaddleCenter = transform.position.x -
					coll.transform.position.x;
				float normalizedBallOffset = ballOffsetFromPaddleCenter /
					halfColliderWidth;
				float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
				float angle = Mathf.PI / 2 + angleOffset;
				Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

				// tell ball to set direction to new direction
				Ball ballScript = coll.gameObject.GetComponent<Ball>();
				ballScript.SetDirection(direction);
			}
		}

		/// <summary>
		/// Checks for a collision on the top of the paddle
		/// </summary>
		/// <returns><c>true</c>, if collision was on the top of the paddle, <c>false</c> otherwise.</returns>
		/// <param name="coll">collision info</param>
		bool TopCollision(Collision2D coll)
		{
			const float tolerance = 0.05f;

			// on top collisions, both contact points are at the same y location
			ContactPoint2D[] contacts = coll.contacts;
			return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
		}
	 
	public void FreezePaddle(int freezeTime)
	{
		
		Debug.Log ("paddle frozen");

		if (freezerTimer.Running) {
			freezerTimer.Duration = freezerTimer.CurrentDuration + freezeTime;
		} 
		else 
		{
			Debug.Log ("freeze timer started");	
			freezerTimer.Duration = freezeTime;
			freezerTimer.Run();
			freeze = true;
		}
	}

}
