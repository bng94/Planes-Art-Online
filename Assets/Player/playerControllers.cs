using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class playerControllers : MonoBehaviour {

	public Rigidbody2D rigidbody;
	public AudioSource planeCollisionClip;
	public AudioSource bulletsCollisionClip;
	public Text healthText;
	public Text levelText;
	public Text playerScore;
	public Text playerName;

	private float horizontal, vertical;
	private float movementSpeed;
	public static bool isFacingRight;

	public float left = -23f;
	public float right = 23f;
	public float top = 13.1f;
	public float bottom = -13.5f;

	public GameObject bullets;
	public Transform shotSpawn;
	public float fireRate = 1f;
	public float nextFire;
	public float tempScoreHolder;

	public int healthPoint = 10;

	// Use this for initialization
	void Start () {
		if (rigidbody == null) {
			rigidbody = GetComponent<Rigidbody2D> ();		
		}
		if (healthText == null) {
			healthText = GameObject.Find ("playerHP").GetComponent<Text> ();
		}
		if (levelText == null) {
			levelText = GameObject.Find ("Level").GetComponent<Text> ();
		}
		if (playerScore == null) {
			playerScore = GameObject.Find ("scoreNumbers").GetComponent<Text> ();
		}
		if (playerName == null) {
			playerName = GameObject.Find ("playerName").GetComponent<Text> ();
		}

		playerName.text = PlayerPrefs.GetString ("playerName");
		tempScoreHolder = PlayerPrefs.GetInt ("Score");
		playerScore.text = tempScoreHolder.ToString ();

		movementSpeed = 14.0f;
		isFacingRight = true;
	}

	// Update is called once per frame, better for input
	void Update () {
		healthText.text = " " + healthPoint;
		tempScoreHolder = PlayerPrefs.GetInt ("Score");
		playerScore.text = tempScoreHolder.ToString ();

		if ((transform.position.x <= right) && (transform.position.x >= left)) 
			horizontal = Input.GetAxis ("Horizontal");
		if ((transform.position.y <= top) && (transform.position.y >= bottom)) 
			vertical = Input.GetAxis ("Vertical");

		if (transform.position.x > right)
			Retrieve ("right");
		if (transform.position.x < left)
			Retrieve ("left");
		if (transform.position.y > top)
			Retrieve ("top");
		if (transform.position.y < bottom)
			Retrieve ("bottom");

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (bullets, shotSpawn.position, shotSpawn.rotation);
		}

		if (healthPoint <= 0) {
			PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") - 1);
			PlayerPrefs.Save ();
			if(levelText.text.Equals("3")){
				SceneManager.LoadScene ("Lost Scene");
			}else{
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}

		}
	}

	//FixedUpdate is better for physics and movement
	void FixedUpdate() {
		rigidbody.velocity = new Vector2 (horizontal * movementSpeed, vertical * movementSpeed);

		if ((horizontal < 0 && isFacingRight) || (horizontal > 0 && !isFacingRight))
			Flip ();
	}

	void Retrieve(string location) {
		if (location == "right")
		{
			rigidbody.transform.position = new Vector2 (right, rigidbody.transform.position.y);
			rigidbody.velocity = new Vector2 (-100, rigidbody.velocity.y);
		}
		if (location == "left")
		{
			rigidbody.transform.position = new Vector2 (left, rigidbody.transform.position.y);
			rigidbody.velocity = new Vector2 (100, rigidbody.velocity.y);
		}
		if (location == "top")
		{
			rigidbody.transform.position = new Vector2 (rigidbody.transform.position.x, top);
			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, -100);
		}
		if (location == "bottom")
		{
			rigidbody.transform.position = new Vector2 (rigidbody.transform.position.x, bottom);
			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, 100);
		}
	}

	void Flip() {
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;
		isFacingRight = !isFacingRight;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "enemy" || healthPoint <= 0) {
			healthText.text = "0";
			healthPoint = 0;
			planeCollisionClip.playOnAwake = true;
			planeCollisionClip.Play ();
			Destroy (gameObject,1.0f);
		}
		if (other.gameObject.tag == "ebullet") {
			healthPoint -= enemyController.attackPower;
			bulletsCollisionClip.playOnAwake = true;
			bulletsCollisionClip.Play ();
			PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") - 1);
			PlayerPrefs.Save ();
		}
	}
}