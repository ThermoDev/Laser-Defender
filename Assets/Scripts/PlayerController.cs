using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	float xMin = -5;
	float xMax = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
//			transform.position += new Vector3( -speed * Time.deltaTime, 0.0f , 0.0f);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.RightArrow	)){
//			transform.position +=  new Vector3( +speed * Time.deltaTime, 0.0f , 0.0f);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.UpArrow	)){
//			transform.position += new Vector3(0.0f, +speed * Time.deltaTime, 0.0f);
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.DownArrow	)){
//			transform.position += new Vector3(0.0f, -speed * Time.deltaTime, 0.0f);
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
	}
}
