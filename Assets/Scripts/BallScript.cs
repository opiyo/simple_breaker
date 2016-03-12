using UnityEngine;
using System.Collections;
 
public class BallScript : MonoBehaviour {
	
	public GameClearScript gameClearScript;
	int speed = 5;
	public int blockCt = 20;
	Rigidbody rb;
	Vector3 vec;
	
	bool isFinish = false;
	
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		rb.AddForce((transform.up + transform.right) * speed, ForceMode.VelocityChange);
    }
	
	void Update ()
	{
		if (blockCt == 0 && !isFinish) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameClearScript.Win();
			isFinish = true;
		}
		
		if (isFinish && Input.GetMouseButtonDown (0)) {
			Application.LoadLevel ("title");
		}
	}
	
	//Ballの動きがループしないようにする
	void OnCollisionEnter (Collision col){
		rb.velocity = rb.velocity.normalized * 8;
		vec = rb.velocity;
		
		if (vec.y >= -5.0f && vec.y <= -0.01f) {
			vec.y = -5.0f;
		}
		if (vec.y >= 0.0f && vec.y <= 5.0f) {
			vec.y = 5.0f;
		}
		if (vec.x >= -5.0f && vec.x <= 0.0f) {
			vec.x = -5.0f;
		}
		if (vec.x >= 0.01f && vec.x <= 5.0f) {
			vec.x = 5.0f;
		}
		rb.velocity = vec;
		
		if (col.gameObject.tag == "Block") {
			blockCt -= 1;
		}
	}
}