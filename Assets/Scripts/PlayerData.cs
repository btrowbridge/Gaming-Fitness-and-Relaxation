using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	//Variables to display
	private int highestLevel;
	private float timeInGame;

	private int medTot;
	private float medDur;

	private int curlsTot;
	private int punchTot;
	private float workDur;

	private int CMTot;
	private float CMDur;
	
	// Use this for initialization
	void Start () 
	{
		//assigning playerprefs to variables
		highestLevel = PlayerPrefs.GetInt("highestLevel");
		timeInGame = PlayerPrefs.GetFloat ("timeInGame");
		
		medTot = PlayerPrefs.GetInt("medTot");
		medDur = PlayerPrefs.GetFloat("medDur");
		
		curlsTot = PlayerPrefs.GetInt("curlTot");
		punchTot = PlayerPrefs.GetInt("punchTot");
		workDur = PlayerPrefs.GetFloat("workDur");
		
		CMTot = PlayerPrefs.GetInt("CMTot");
		CMDur = PlayerPrefs.GetFloat("CMDur");
	}
	
	// loop on the GUI
	void OnGUI()
	{
		//setting up the GUI
		GUILayout.BeginHorizontal ();
		
		GUILayout.Space (100);

		GUILayout.BeginVertical ();

		GUILayout.Space (150);


		GUILayout.Label ("Highest Level Achieved: " + highestLevel);
		GUILayout.Label ("Time spent in game: " + timeInGame);

		GUILayout.Space (10);

		GUILayout.Label ("Total successful meditation: " + medTot);
		GUILayout.Label ("Total time spent meditating: " + medDur);

		GUILayout.Space (10);

		GUILayout.Label ("Total number of curls: " + curlsTot);
		GUILayout.Label ("Total number of punches: " + punchTot);
		GUILayout.Label ("Time spent working out: " + workDur);

		GUILayout.Space (10);

		GUILayout.Label ("Successful calm motion: " + CMTot);
		GUILayout.Label ("Time spent attempting calm motion: " + CMDur);
	}
	//Button to save data
	public void Save()
	{
		PlayerPrefs.Save();
	}
	//button to dlete all data and refresh the GUI
	public void Delete()
	{
		PlayerPrefs.DeleteAll();
		OnGUI ();
	}
}
