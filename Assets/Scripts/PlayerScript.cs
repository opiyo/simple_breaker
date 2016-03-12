using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private Vector3 pos;
	private Vector3 WorldPointPos;
	
	private float playerLength; // バーの長さ
	// マウスが移動できる限界地点
	private float maxLeftPos = -1.9f;
	private float maxRightPos = 1.9f;

	void Start(){
		playerLength = transform.localScale.x;
	}

	void Update (){
		// マウス位置座標をスクリーン座標からワールド座標に変換する
		WorldPointPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		// 壁を突き抜けないようにx軸の移動範囲を限定
		if (WorldPointPos.x <= maxLeftPos) {
			WorldPointPos.x = maxLeftPos;
		} else if (WorldPointPos.x >= maxRightPos) {
			WorldPointPos.x = maxRightPos;
		}
		//y軸とz軸は固定
		WorldPointPos.y = -3.0f;
		WorldPointPos.z = 0.0f;
		
		// ワールド座標をPlayer位置へ変換
		gameObject.transform.position = WorldPointPos;
	}
	
	void OnTriggerEnter (Collider col)
	{
		// アイテムにぶつかった時
		if (col.tag == "Item") {
			// アイテムを消す
			Destroy (col.gameObject);
			// ItemTypeによって、ExtendPlayerLengthかShrinkPlayerLengthどちらかを呼ぶ
			if (col.GetComponent<ItemScript> ().itemType == ItemScript.ItemType.ExtendPlayerLength) {
				ExtendPlayerLength();
			} else if(col.GetComponent<ItemScript>().itemType == ItemScript.ItemType.ShrinkPlayerLength){
				ShrinkPlayerLength();
			}
		}
	}
	
	void ExtendPlayerLength ()
	{
		// playerLengthを0.5長くする(2.5以上なら変更させない)
		playerLength += 0.5f;
		if (playerLength > 2.5f) {
			playerLength = 2.5f;
		}
		
		// 変更したplayerLengthをオブジェクトに反映する
		var temp = transform.localScale;
		temp.x = playerLength;
		gameObject.transform.localScale = temp; 
		
		// バーが長くなったので、マウスが移動できる限界地点を調整する
		maxLeftPos += 0.25f;
		maxRightPos -= 0.25f;
	}
	
	void ShrinkPlayerLength ()
	{
		// playerLengthを0.5短くする(1.0以下なら変更させない)
		playerLength -= 0.5f;
		if (playerLength < 1.0f) {
			playerLength = 1.0f;
		}
		
		// 変更したplayerLengthをオブジェクトに反映する
		var temp = transform.localScale;
		temp.x = playerLength;
		gameObject.transform.localScale = temp;
		
		// バーが短くなったので、マウスが移動できる限界地点を調整する
		maxLeftPos -= 0.25f;
		maxRightPos += 0.25f;
	}
}