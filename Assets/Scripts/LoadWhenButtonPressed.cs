using UnityEngine;
using System.Collections;

public class LoadWhenButtonPressed : MonoBehaviour {

	//needs to be accessible and returns nothing

	public void LoadScene(int MenuOrGame)
	{
		Application.LoadLevel (MenuOrGame);
	}
}
