using UnityEngine;
using System.Collections;

public class EnemyShipController : MonoBehaviour {
	private Projectile projectile;
	public float health = 100f;

	void OnTriggerEnter2D(Collider2D collider){
		projectile = collider.gameObject.GetComponent<Projectile>();
		if(projectile != null){
			health -= projectile.GetDamage();
			projectile.Hit();

			if(health <= 0){
				Destroy(gameObject);
			}
			print ("Woot");
		}
	}
}
