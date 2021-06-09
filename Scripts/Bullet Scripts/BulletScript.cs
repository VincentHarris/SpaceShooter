using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public float speed = 5f;
	public float deactivate_Timer = 3f;

	[HideInInspector]
	public bool is_EnemyBullet = false;


	// Use this for initialization
	void Start () {
		if (is_EnemyBullet)
			speed *= -1f;

		Invoke ("DeactivateGameObject", deactivate_Timer);

	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		Vector3 temp = transform.position;
		temp.x += speed * Time.deltaTime;
		transform.position = temp;
	}

	void DeactivateGameObject(){
		gameObject.SetActive (false);
	
	}


	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Bullet" || target.tag == "Enemy") {
			gameObject.SetActive (false);
		}
	}

}//class
