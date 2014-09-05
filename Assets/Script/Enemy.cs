using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{

	Animator enemy;
	Transform pos_player;

	float speed = 0.1f;
	float tempo;
	float direcao;

	bool r_tempo = false;
	bool right = false;

	// Use this for initialization
	void Start () 
	{
		enemy = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		pos_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().target;

		if(direcao > 0 &&!right)
		{
			Flip();
		}
		else if(direcao < 0 && right)
		{
			Flip();
		}

		if(Vector2.Distance(transform.position, pos_player.position) > 3)
		{
			direcao = transform.position.x - pos_player.position.x;
			Run();
		}
		else
		{
			enemy.SetBool("Run", false);
			r_tempo = true;
			Attack();
		}
	}

	void Attack()
	{
		if(r_tempo)
		{
			tempo = 0.5f + Time.time;
		}
		r_tempo = false;
		enemy.SetBool("Attack", true);
		if(Time.time > tempo)
		{
			enemy.SetBool("Attack", false);
		}
	}

	void Run()
	{
		enemy.SetBool("Attack", false);
		enemy.SetBool("Run", true);
		Vector2 direction;
		direction = pos_player.position - transform.position;
		direction.Normalize();
		transform.Translate(direction * speed);
	}

	void Flip()
	{
		right = !right;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{

	}
}
