using UnityEngine;
using System.Collections;

public class Pergunta1 : MonoBehaviour 
{
	public string per1 = "";
	public static Pergunta1 instance;
	
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
		//Debug.Log(per1);
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(235, 70, 50, 20), "Bom"))
		{
			per1 = "Desenvolver jogor e? Resposta: Bom";
		}
		if (GUI.Button(new Rect(288, 70, 50, 20), "Ruim"))
		{
			per1 = "Desenvolver jogor e? Resposta: Ruim";
		}
		if (GUI.Button(new Rect(344, 70, 55, 20), "Demais"))
		{
			per1 = "Desenvolver jogor e? Resposta: Demais";
		}
	}
}