using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed = 5f;
	public float rotate_speed = 50f;

	public bool canShoot;
	public bool canRotate;
	public bool canMove = true;

	public float bound_X = -11f; //will despawn the enemy once it passes -11 coord in the game grid (which is just offscreen to the left)

	public Transform attack_Point;
	public GameObject bulletPrefab;

	private Animator anim;
	private AudioSource explosionSound;



	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		explosionSound = GetComponent<AudioSource> ();
	}

	void Start(){
		if (canRotate) {
			//the range is 0 or 1, 2 is excluded
			if(Random.Range(0,2)>0){
				rotate_speed = Random.Range(rotate_speed, rotate_speed +20f);
				rotate_speed *= -1f; //this will make the object either rotate for backwards
			}
		}
		if(canShoot)
			Invoke("StartShooting", Random.Range(1f,3f));
	}

	// Update is called once per frame
	void Update () {
		Move ();
		RotateEnemy ();
	
	}

	//We're not moving the enemy using inputs, the enemy moves on their own and moves to the left.
	void Move(){
		if (canMove) {
			//constantly gets the pos of the enemy, stores it into temp variable and moves its x-coord left by subtracting speed
			Vector3 temp = transform.position;
			temp.x -= speed * Time.deltaTime; 
			transform.position = temp;

			//Turns off the gameobject when it is less than the bound (further left on the grid)
			if (temp.x < bound_X)
				gameObject.SetActive (false);
		}
	}
	void RotateEnemy(){
		if (canRotate) {
			transform.Rotate (new Vector3 (0f, 0f, rotate_speed * Time.deltaTime), Space.World);
		}
	
	}

	void StartShooting(){
		//GameObject bullet = Instantiate (bulletPrefab, attack_Point.position, Quaternion.identity); //throws and error

		//Does not throw an error, but the enemy bullets will not invoke
		GameObject bullet =(GameObject) Instantiate (bulletPrefab, attack_Point.position, Quaternion.identity);
		bullet.GetComponent<BulletScript>().is_EnemyBullet = true;

		if(canShoot)
			Invoke("StartShooting", Random.Range(1f,3f));
	}

} // class
