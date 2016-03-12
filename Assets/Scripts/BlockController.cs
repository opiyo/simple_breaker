using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	void OnCollisionEnter (Collision col)
	{
		Destroy (gameObject);
		
		//アイテムを1/5の確立で生成
		if (Random.Range (0, 5) == 0) {
			CreateItem();
		}
	}
	
	void CreateItem(){
		//ResourcesフォルダからItemPrefab取得
		var item = Resources.Load<GameObject>("Prefabs/Item");
		//アイテムをHierarchy上に生成 positionはBlock, rotationはItemPrefab
		GameObject obj = Instantiate(item, gameObject.transform.position,item.transform.rotation) as GameObject;
		// 1/2の確立でアイテムの種類を決定
		switch(Random.Range(0, 2)){
		case 0:
			// 赤色にする
			obj.GetComponent<Renderer>().material.color = Color.red;
			// ItemTypeをExtendPlayerLengthにする
			obj.GetComponent<ItemScript>().itemType = ItemScript.ItemType.ExtendPlayerLength;
			break;
			
		case 1:
			// 黒色にする
			obj.GetComponent<Renderer>().material.color = Color.black;
			// ItemTypeをShrinkPlayerLengthにする
			obj.GetComponent<ItemScript>().itemType = ItemScript.ItemType.ShrinkPlayerLength;
			break;
			
		default:
			break;
		}
	}
}