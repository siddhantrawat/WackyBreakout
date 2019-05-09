using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
	static ConfigurationData Config;
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
		get { return Config.PaddleMoveUnitsPerSecond; }
    }

	public static float BallImpulseForce
	{
		get{return Config.BallImpulseForce; }
	}

	public static float BallLifeTime
	{
		get{return Config.BallLifeTime; }
	}

	public static float MinBallSpawnTime
	{
		get { return Config.MinBallSpawnTime; }
	}


	public static float MaxBallSpawnTime
	{
		get { return Config.MaxBallSpawnTime; }
	}

	public static float StandardBlockPoints
	{
		get {return Config.StandardBlockPoints; }
	}

	public static float BonusBlockPoints
	{
		get {return Config.BonusBlockPoints; }
	}

	public static float PickUpBlockPoints
	{
		get {return Config.PickUpBlockPoints; }
	}

	public static float ProbStandard
	{
		get { return Config.ProbStandard; }
	}

	public static float ProbBonus
	{
		get { return Config.ProbBonus; }
	}

	public static float ProbPickUp
	{
		get { return Config.ProbPickUp; }
	}

	public static int TotalBalls
	{
		get { return Config.TotalBalls; }
	}

	public static int FreezerEffectDuration 
	{
		get { return Config.FreezerEffectDuration; }
	}

	public static int SpeedupEffectDuration 
	{
		get { return Config.SpeedupEffectDuration; }
	}

	public static int SpeedupFactor
	{
		get { return Config.SpeedupFactor; }
	}
	#endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
		Config= new ConfigurationData();
    }
}
