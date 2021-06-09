using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	public float min_Y, max_Y;

	[SerializeField]
	private GameObject player_Bullet;

	[SerializeField]
	private Transform attack_Point;


	public float attack_Timer =0.35f; //used to restrict the amount of bullets the player can fire
	private float current_Attack_Timer;
	private bool canAttack;

	// Use this for initialization
	void Start () {
		current_Attack_Timer = attack_Timer;
	
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer ();
		Attack ();
	
	}


	void MovePlayer(){
		if (Input.GetAxisRaw ("Vertical") > 0f) {

			Vector3 temp = transform.position;
			temp.y += speed * Time.deltaTime;

			//makes it so that once the player reaches the top of the screen, the ship cannot move past it
			if (temp.y > max_Y) 
				temp.y = max_Y;

			transform.position = temp;

		} else if (Input.GetAxisRaw ("Vertical") < 0f) {

			Vector3 temp = transform.position;
			temp.y -= speed * Time.deltaTime;

			//makes it so that once the player reaches the bottom of the screen, the ship cannot move past it
			if (temp.y < min_Y)
				temp.y = min_Y;

			transform.position = temp;
		}

	}

	void Attack(){
		attack_Timer += Time.deltaTime;
		if (attack_Timer > current_Attack_Timer) {
			canAttack = true;
		}

		if (Input.GetKeyDown (KeyCode.K)) {
			if (canAttack) {
				canAttack = false;
				attack_Timer = 0f;
				Instantiate (player_Bullet, attack_Point.position, Quaternion.identity);
				//Play sound effect
			}
		}
	}
}//class
