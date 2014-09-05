using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	Animator player;
	public Transform target;
	public static Player instance;
	
	float pos_x;
	float pos_y;
	
	bool right = false;
	bool jump = true;
	public bool morreu = false;
	
	void Awake()
	{
		instance = this;	
	}
	
	// Use this for initialization
	void Start () 
	{
		player = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		pos_x = Input.GetAxis("Horizontal");
		pos_y = Input.GetAxis("Vertical");
		
		transform.Translate(pos_x, 0, 0);
		
		if(pos_x < 0 && !right)
		{
			Flip();
		}
		else if(pos_x > 0 && right)
		{
			Flip();
		}
		
		if(pos_x != 0)
		{
			player.SetBool("Run", true);
		}
		else
		{
			player.SetBool("Run", false);
		}
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			morreu = true;
			player.SetBool("Atack", true);
		}
		else
		{
			morreu = false;
			player.SetBool("Atack", false);
		}

		if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && jump)
		{
			rigidbody2D.AddForce(new Vector2(0f, 450));
			player.SetBool("Jump", true);
			jump = false;
		}
		else
		{
			player.SetBool("Jump", false);
		}
	}
	
	void Flip()
	{
		right = !right;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnTriggerStay2D (Collider2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			if(Input.GetKey(KeyCode.Space))
			{
				Destroy(other.gameObject, 0.2f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "Platform")
		{
			jump = true;
		}
	}
}