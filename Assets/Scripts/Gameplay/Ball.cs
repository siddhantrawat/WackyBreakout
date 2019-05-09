using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour {

	Rigidbody2D rb2d;
	Timer timer;
	bool spawn = false;
	BallSpawner ballSpawn;
	Vector2 normalVelocity;
	bool speedupActive = false;
    ReduceBallLeftEvent reduceBallLeftEvent = new ReduceBallLeftEvent();
    SpawnBallEvent spawnBallEvent = new SpawnBallEvent();

	// Use this for initialization
	void Start () {
		timer =	gameObject.AddComponent<Timer> ();
	
		timer.Duration = ConfigurationUtils.BallLifeTime;
		timer.Run ();
		ballSpawn = Camera.main.GetComponent<BallSpawner>();

		rb2d = GetComponent<Rigidbody2D> ();
        EventManager.AddBallInvoker(this);
        EventManager.AddSpawnInvoker(this);
        EventManager.AddListersToSpeed (speedup);

    }


	// Update is called once per frame
	void Update () {

		//spawn
			if (timer.ElapsedSeconds>1 && !spawn){
				spawn = true;
				moveBall ();
			}
			if (timer.Finished) {
				Destroy (gameObject);
                spawnBallEvent.Invoke();

        }	
	
			if (timer.Running && gameObject.transform.position.y < ScreenUtils.ScreenBottom) {
                     spawnBallEvent.Invoke();
                    Destroy (gameObject);
                    reduceBallLeftEvent.Invoke();
			}
		 	
		if (!EffectUtils.isActive && speedupActive) {
			Vector2 newVelocity = rb2d.velocity /EffectUtils.SpeedupFactor;
			rb2d.velocity = newVelocity;
			speedupActive = false ;
		}
	}

	public void SetDirection(Vector2 direction)
	{
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

	void moveBall()
	{
		float angle = -90 * Mathf.Deg2Rad;

		float impulse;

		if (EffectUtils.isActive) {
			impulse = ConfigurationUtils.BallImpulseForce * EffectUtils.SpeedupFactor;
		} 
		else {
			impulse = ConfigurationUtils.BallImpulseForce;
		}

		Vector2 force = new Vector2 (
				impulse * Mathf.Cos (angle),
				impulse * Mathf.Sin (angle));
		GetComponent<Rigidbody2D> ().AddForce (force);
			
	}
	public void speedup(int duration, int factor)
	{
		if (!speedupActive) {
			Vector2 newVelocity = rb2d.velocity * factor;
			rb2d.velocity = newVelocity;
			speedupActive = true;
		}
	}

    public void AddReduceBallListener(UnityAction listener)
    {
        reduceBallLeftEvent.AddListener(listener);
    }

    public void AddSpawnListener(UnityAction listener)
    {
        spawnBallEvent.AddListener(listener);
    }
}
