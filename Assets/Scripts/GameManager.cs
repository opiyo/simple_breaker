using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public AudioClip audioClip;
	AudioSource audioSource;
	
	void Awake ()
	{
		//インスタンスが存在したら
		if (instance != null)
		{
			//インスタンスを破棄
			Destroy(this.gameObject);
		}
		//インスタンスがなかったら
		else if (instance == null)
		{
			//このオブジェクトをインスタンスとする
			instance = this;
		}
		//シーンを跨いでもインスタンスを破棄しない
		DontDestroyOnLoad (this.gameObject);
	}
	
	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = audioClip;
		audioSource.Play();
	}
	
	// スマートフォンの戻るキーで終了
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}