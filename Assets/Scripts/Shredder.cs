using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider) {
		// Gets the gameObject from the collider itself.
		Destroy(collider.gameObject);
	}
}
