using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float padding;
	
	float xMin;
	float xMax;
	float yMin;
	float yMax;

	// Use this for initialization
	void Start () {
		// Find which plane your projecting your point on screen, to point on worldspace.
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance) );
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance) );
		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;
		
		Vector3 upMost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance) );
		Vector3 downMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance) );
		yMin = downMost.y + padding;
		yMax = upMost.y - padding;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
//			transform.position += new Vector3( -speed * Time.deltaTime, 0.0f , 0.0f);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.RightArrow	)){
//			transform.position +=  new Vector3( +speed * Time.deltaTime, 0.0f , 0.0f);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.UpArrow	)){
//			transform.position += new Vector3(0.0f, +speed * Time.deltaTime, 0.0f);
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.DownArrow	)){
//			transform.position += new Vector3(0.0f, -speed * Time.deltaTime, 0.0f);
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		
		// Restricts player movement to play space :)
		float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
		float newY = Mathf.Clamp(transform.position.y, yMin, yMax );
		transform.position = new Vector3(newX, newY, transform.position.z);
	}
}
