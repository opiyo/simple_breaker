using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	//アイテムタイプのenum
	//PlayerScriptのOnTriggerEnterでアイテムの種類を判別するために利用
	public enum ItemType{
		ExtendPlayerLength,
		ShrinkPlayerLength,
	}
	public ItemType itemType;
	
	Rigidbody rb;
	Vector3 vec;
	float itemSpeed = -3.0f;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		vec = new Vector3(0, itemSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = vec;
	}
}
