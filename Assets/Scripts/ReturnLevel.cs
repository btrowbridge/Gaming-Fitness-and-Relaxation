using UnityEngine;
using System.Collections;

public class ReturnLevel : MonoBehaviour {


	//return to level upon leaving game
	public void ReturnToLevel()
	{
		GameMaster.level--;
	}
}
