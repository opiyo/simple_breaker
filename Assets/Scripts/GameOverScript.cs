using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	void Start () {
		gameObject.GetComponent<Text>().enabled = false;
	}
	
	public void Lose () {
		gameObject.GetComponent<Text>().enabled = true;
	}
}
