using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameClearScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text>().enabled = false;
	}
	
	// Update is called once per frame
	public void Win () {
		gameObject.GetComponent<Text>().enabled = true;
	}
}