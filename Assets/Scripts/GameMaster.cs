using UnityEngine;
using System.Collections;


public class GameMaster : MonoBehaviour 
{	
	public static int playerFoodPoints = 100;	//Static Starting value for Player food points.
	public static int playerAmmo = 10;			//playerAmmo can be accessed from other scripts
	public static int damage = 1;				//damage can be accessed from other scripts
	public static GameMaster instance = null;	//Static instance of GameMaster which allows it to be accessed by any other script.

	//how many actions grants one of each stat
	public int secondsPerAmmo = 1;
	public int liftsPerDamage = 20;
	public int secondsPerHealth = 2;


	//saves players level
	public static int level = 0;

	// Use this for initialization
	void Awake () 
	{

		//Check if instance already exists
		if (instance == null)
			
			//if not, set instance to this
			instance = this;

		
		//Sets this to not be destroyed when reloading scene

		DontDestroyOnLoad (gameObject);
	}

	//adds to player damage
	public void AddToDamage(int liftResults)
	{
		damage += Mathf.RoundToInt(liftResults/liftsPerDamage);
	}

	//adds to Player health
	public void AddToHealth(int CMResults)
	{
		playerFoodPoints += Mathf.RoundToInt(CMResults/secondsPerHealth);
	}

	//adds to player ammo
	public void AddToAmmo(int medResults)
	{
		playerAmmo += Mathf.RoundToInt (medResults/secondsPerAmmo);
	}

	// Update is called once per frame

}
