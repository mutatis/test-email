using UnityEngine;
using System.Collections;
using System;

public class Nome : MonoBehaviour 
{
	public string nome = "";
	public static Nome instance;

	void Awake()
	{
		instance = this;	
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		nome = GUI.TextField(new Rect(235, 20, 200, 20), nome, 100);
	}
}