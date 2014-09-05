using UnityEngine;
using System.Collections;

public class Pergunta2 : MonoBehaviour
{
	public string per2 = "";
	string per2_escrita = "ou digite sua opniao aqui!";
	public static Pergunta2 instance;
	
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
		Debug.Log(per2);
		if(per2_escrita != "")
		{
			per2 = "O que voce acha da politica? Resposta: " + per2_escrita;
		}
	}
	
	void OnGUI()
	{
		if (GUI.Button(new Rect(235, 120, 50, 20), "Boa"))
		{
			per2 = "O que voce acha da politica? Resposta: Boa";
		}
		if (GUI.Button(new Rect(288, 120, 50, 20), "Ruim"))
		{
			per2 = "O que voce acha da politica? Resposta: Ruim";
		}
		per2_escrita = GUI.TextField(new Rect(344, 120, 200, 20), per2_escrita, 100);
	}
}
