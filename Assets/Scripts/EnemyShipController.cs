using UnityEngine;
using System.Collections;

public class EnemyShipController : MonoBehaviour {
	private Projectile projectile;
	public float health = 100f;
	public GameObject beam;
	public float projectileSpeed;
	public float firingRate;
	public float shotsPerSecond = 0.5f;

	private static string fireLazerMethodName = "FireLaser";
	
	void Start() {

	}

	void Update () {
		float probability = Time.deltaTime * shotsPerSecond;
		if(Random.value < probability){
			FireLaser();
		}
	}

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

	void FireLaser(){
		Vector3 offset = new Vector3(0,0.2f);
		GameObject laser = (GameObject)Instantiate(beam, transform.position - offset, Quaternion.identity);
		laser.rigidbody2D.velocity = new Vector3(0, -projectileSpeed, 0);
	}

}
