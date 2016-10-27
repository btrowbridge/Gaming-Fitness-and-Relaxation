using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeditationCM : MonoBehaviour
{
	public Texture2D[] signalIcons;
	public Text medValue;
	public Text medSeconds;

	//To grab myo data
	public GameObject myo1;
	public GameObject myo2;


	private int indexSignalIcons = 1;
	private float timeMed = 0;
	private Rigidbody gameBody;


	TGCConnectionController controller;
	
	
	private int poorSignal1;
	//private int attention1;
	public int meditation1;

	//playerprefs
	private float CMDur;
	private int CMTot;
	
	//private float delta;

	//find rab myo data

	public ThalmicMyo thalmicMyo1; 
	public ThalmicMyo thalmicMyo2; 

	
	void Start()
	{
		//assign playerpref data
		CMDur = PlayerPrefs.GetFloat ("CMDur");
		CMTot = PlayerPrefs.GetInt ("CMTot");

		//find TCG controller
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		
		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		//controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		
		//controller.UpdateDeltaEvent += OnUpdateDelta;

		thalmicMyo1 = myo1.GetComponent<ThalmicMyo> ();
		thalmicMyo2 = myo2.GetComponent<ThalmicMyo> ();


		//initiate controller
		controller.Connect ();
	}

	//initiate controller
	void OnLevelWasLoaded()
	{

	}
	

	
	void OnUpdatePoorSignal(int value)
	{
		//assign signal icon to amount of connectivity
		poorSignal1 = value;
		if(value < 25){
			indexSignalIcons = 0;
		}else if(value >= 25 && value < 51){
			indexSignalIcons = 4;
		}else if(value >= 51 && value < 78){
			indexSignalIcons = 3;
		}else if(value >= 78 && value < 107){
			indexSignalIcons = 2;
		}else if(value >= 107){
			indexSignalIcons = 1;
		}
	}
	/*
	void OnUpdateAttention(int value){
		attention1 = value;
	}
	*/
	void OnUpdateMeditation(int value){
		meditation1 = value;
		
	}
	/*
	void OnUpdateDelta(float value){
		delta = value;
	}
	*/
	void Update ()
	{
		//update duration spent
		CMDur += Time.deltaTime;


		//check for calm movement
		if ((meditation1 >= 75) && ((thalmicMyo1.gyroscope.magnitude > 1) || (thalmicMyo2.gyroscope.magnitude > 1)) )
		{
			//if condition met, update seconds of CM
			timeMed += Time.deltaTime;
			//update med seconds
			medSeconds.text = Mathf.RoundToInt(timeMed).ToString() + "s";
		}

		medValue.text = meditation1.ToString ();
	}

	void OnDisable()
	{
		//disconnect controller
		controller.Disconnect ();

		//calculate results
		int results = Mathf.RoundToInt(timeMed * 10);
		GameMaster.instance.AddToHealth (results);

		//reassigning player data
		PlayerPrefs.SetFloat ("CMDur", CMDur);
		PlayerPrefs.SetInt ("CMTot", CMTot + Mathf.RoundToInt (timeMed));

	}

	//set up GUI
	void OnGUI()
	{

		GUILayout.Space (50);
		
		GUILayout.BeginHorizontal();
		
		/*
        if (GUILayout.Button("Connect"))
        {
            controller.Connect();
        }
        if (GUILayout.Button("DisConnect"))
        {
            controller.Disconnect();
			indexSignalIcons = 1;
        }
		*/

		//signal icons
		GUILayout.Space(Screen.width-50);
		GUILayout.Label(signalIcons[indexSignalIcons]);
		GUI.DrawTexture(new Rect(0,0,25,25), signalIcons [indexSignalIcons], ScaleMode.ScaleToFit);
		
		GUILayout.EndHorizontal();


		/*
        GUILayout.Label("PoorSignal1:" + poorSignal1);
        GUILayout.Label("Attention1:" + attention1);
        GUILayout.Label("Meditation1:" + meditation1);
		GUILayout.Label("Delta:" + delta);
		*/
		
	}
}