using UnityEngine;
using System.Collections;

public class enemyBulletController : MonoBehaviour {

	public Rigidbody2D rigid;
	public AudioSource bulletCollision;

	public float moveX;
	public float speed = 5.0f;

	public float left = -23f;
	public float right = 23f;
	public float top = 13.1f;
	public float bottom = -13.5f;

	// Use this for initialization
	void Start () {
		Vector3 bulletScale = transform.localScale;
		if (rigid == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}
		if (bulletCollision == null) {
			bulletCollision = GetComponent <AudioSource> ();
		}
		if (enemyController.isFacingRight) {
			moveX = 1;
		}else {
			moveX = -1;
			bulletScale.x = bulletScale.x * -1;
			transform.localScale = bulletScale;
		}
	}

	// Update is called once per frame
	void Update () {
		rigid.velocity = new Vector2 (moveX * speed, rigid.velocity.y);

		if ((transform.position.x > right) || (transform.position.x < left) || (transform.position.y > top) || (transform.position.y < bottom))
			Destroy (gameObject);

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "pbullet") {
			bulletCollision.playOnAwake = true;
			bulletCollision.Play ();
			Destroy (gameObject, 0.1f);
		}
		if (other.CompareTag("Player")) {
			Destroy (gameObject);
		}
	}
}
