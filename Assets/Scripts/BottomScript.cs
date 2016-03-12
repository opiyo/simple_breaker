using UnityEngine;
using System.Collections;

public class BottomScript : MonoBehaviour {
	public GameOverScript gameOver;
	bool goTitle = false;
	
	void Update (){
		if (goTitle) {
			//GameOverの文字が表示された状態で画面をクリック
			if(Input.GetMouseButtonDown (0)){
				Application.LoadLevel ("title");//タイトル画面へ遷移
			}
		}
	}
	
	void OnCollisionEnter(Collision col) {
		Destroy(col.gameObject);//ボール消滅
		//GameOverの文字を表示させる
		gameOver.Lose();
		goTitle = true;//Update文の実行
	}
}