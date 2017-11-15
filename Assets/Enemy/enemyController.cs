using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyController : MonoBehaviour {

	public Rigidbody2D rigid;
	public AudioSource planeCollisionClip;
	public AudioSource bulletsCollisionClip;
	public Text healthText;
	public Text levelText;

	public float movementSpeed = 1.0f;
	public float horizontal;
	public float vertical;
	public static bool isFacingRight = false;

	public float left = -23f;
	public float right = 23f;
	public float top = 13.1f;
	public float bottom = -13.5f;

	public GameObject bullets;
	public Transform shotSpawn;
	public float fireRate = 1f;
	public float nextFire;
	public static int attackPower;
	private int healthPoint;

	// Use this for initialization
	void Start () {
		if (rigid == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}
		if (healthText == null) {
			healthText = GameObject.Find ("enemyHP").GetComponent<Text> ();
		}
		if (levelText == null) {
			levelText = GameObject.Find ("Level").GetComponent<Text> ();
		}
		horizontal = Random.Range (-10, 10);
		vertical = Random.Range (-10, 10);

		if(levelText.text.Equals("1")){
			healthPoint = 10;
			attackPower = 1;
		}
		if(levelText.text.Equals("2")){
			attackPower = 2;
			healthPoint = 10;
		}
		if(levelText.text.Equals("3")){
			attackPower = 2;
			healthPoint = 20;
		}
	}
		
	// Update is called once per frame, better for input
	void Update() {
		healthText.text = " " + healthPoint;

		if (Time.time > nextFire)
		{	
			nextFire = Time.time + fireRate;
			Instantiate (bullets, shotSpawn.position, shotSpawn.rotation);
		}

		if (transform.position.x > right)
		{
			Retrieve ("right");
			Flip ();
		}
		if (transform.position.x < left)
		{
			Retrieve ("left");
			Flip ();
		}
		if (transform.position.y > top)
			Retrieve ("top");
		if (transform.position.y < bottom)
			Retrieve ("bottom");

		if (healthPoint <= 0) {
			planeCollisionClip.playOnAwake = true;
			planeCollisionClip.Play ();
			PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 10);
			PlayerPrefs.Save ();
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}

	//FixedUpdate is better for physics and movement
	void FixedUpdate (){
		rigid.velocity = new Vector2 (horizontal * movementSpeed, rigid.velocity.y);
		rigid.velocity = new Vector2 (rigid.velocity.x, vertical * movementSpeed);
	}

	void Flip()	{
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;
		isFacingRight = !isFacingRight;
	}

	void setMoveXY (){
		horizontal = Random.Range(-10,10);
		vertical = Random.Range(-10,10);
		if (horizontal == 0 || vertical == 0) {
			setMoveXY ();
		}
	}

	void Retrieve(string location){
		if (location == "right")
		{
			rigid.transform.position = new Vector2 (right, rigid.transform.position.y);
			rigid.velocity = new Vector2 (-100, rigid.velocity.y);
			setMoveXY();
		}
		if (location == "left")
		{
			rigid.transform.position = new Vector2 (left, rigid.transform.position.y);
			rigid.velocity = new Vector2 (100, rigid.velocity.y);
			setMoveXY();
		}
		if (location == "top")
		{
			rigid.transform.position = new Vector2 (rigid.transform.position.x, top);
			rigid.velocity = new Vector2 (rigid.velocity.x, -100);
			setMoveXY();
		}
		if (location == "bottom")
		{
			rigid.transform.position = new Vector2 (rigid.transform.position.x, bottom);
			rigid.velocity = new Vector2 (rigid.velocity.x, 100);
			setMoveXY();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			healthText.text = "0";
			Destroy (gameObject,1.0f);
		}
		if (healthPoint <= 0) {
			healthPoint = 0;
			healthText.text = "0";
			Destroy (gameObject,1.0f);
		}
		if (other.gameObject.tag == "pbullet") {
			bulletsCollisionClip.playOnAwake = true;
			bulletsCollisionClip.Play ();
			healthPoint -= 1;
			PlayerPrefs.Save ();
		}
	}
}