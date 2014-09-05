using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour 
{

	float pos_x;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		pos_x = Input.GetAxis("Horizontal");
		transform.Translate(pos_x, 0, 0); 
	}
}
