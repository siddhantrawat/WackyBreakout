using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
	static float ballLifeTime = 10;
	static float minBallSpawnTime = 5;
	static float maxBallSpawnTime = 10;
	static float standardBlockPoints = 1;
	static float bonusBlockPoints = 5;
	static float pickUpBlockPoints = 8;
	static float probStandard = .5f;
	static float probBonus = .33f;
	static float probPickUp = .17f;
	static int totalBalls = 10;
	static int freezerEffectDuration = 2;
	static int speedupEffectDuration = 2;
	static int speedupFactor = 20;
	#endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

	//Get ballLifeTime

	public float BallLifeTime
	{
		get { return ballLifeTime; }
	}


	public float MinBallSpawnTime
	{
		get { return minBallSpawnTime; }
	}


	public float MaxBallSpawnTime
	{
		get { return maxBallSpawnTime; }
	}

	public float StandardBlockPoints
	{
		get { return standardBlockPoints; }
	}

	public float BonusBlockPoints
	{
		get { return bonusBlockPoints; }
	}

	public float PickUpBlockPoints
	{
		get { return pickUpBlockPoints; }
	}

	public float ProbStandard
	{
		get { return probStandard; }
	}

	public float ProbBonus
	{
		get { return probBonus; }
	}

	public float ProbPickUp
	{
		get { return probPickUp; }
	}

	public int TotalBalls
	{
		get { return totalBalls; }
	}

	public int FreezerEffectDuration
	{
		get { return freezerEffectDuration; }
	}


	public int SpeedupEffectDuration
	{
		get { return speedupEffectDuration; }
	}


	public int SpeedupFactor
	{
		get { return speedupFactor; }
	}


    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
		StreamReader read = null;
		try{
			read = File.OpenText (Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
			String names = read.ReadLine(); 
			string values = read.ReadLine();
			SetConfigurationDataFields(values);
		}
		catch(Exception e) {
			Console.WriteLine (e.Message);
		}
		finally{
			if (read != null)
				read.Close ();
			}
		}
	public static void SetConfigurationDataFields(String csvValues)
	{
		String[] values = csvValues.Split (',');
		paddleMoveUnitsPerSecond = float.Parse(values [0]);
		ballImpulseForce = float.Parse(values [1]);
		ballLifeTime = float.Parse (values[2]);
		minBallSpawnTime = float.Parse (values[3]);
		maxBallSpawnTime = float.Parse (values[4]);
		standardBlockPoints = float.Parse (values[5]);
		bonusBlockPoints = float.Parse (values[6]);
		pickUpBlockPoints = float.Parse (values [7]);
		probStandard = float.Parse (values[8]);
		probBonus = float.Parse (values[9]);
		probPickUp = float.Parse (values[10]);
		totalBalls = int.Parse (values[11]);
		freezerEffectDuration = int.Parse (values[12]);
		speedupEffectDuration = int.Parse (values[13]);
		speedupFactor = int.Parse (values[14]);
	}

    #endregion
}
