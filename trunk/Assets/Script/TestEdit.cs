using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class TestEdit : MonoBehaviour 
{
	public GUIStyle style;
	public string stringToEdit = "Oi";
	string per1 = "";
	string per2 = "";
	string nome = "";
	public Texture btnTexture;

	void Update()
	{
		nome = GameObject.FindGameObjectWithTag("Nome").GetComponent<Nome>().nome;
		per1 = GameObject.FindGameObjectWithTag("Per1").GetComponent<Pergunta1>().per1;
		per2 = GameObject.FindGameObjectWithTag("Per2").GetComponent<Pergunta2>().per2;
	}

	void Email()
	{
		MailMessage mail = new MailMessage();
		
		mail.From = new MailAddress(stringToEdit);
		mail.To.Add(stringToEdit);
		mail.Subject = "Test Mail";
		mail.Body = nome + Environment.NewLine + per1 + Environment.NewLine + per2;
		
		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("Lootatis@gmail.com", "Select.10") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
		{ return true; };
		smtpServer.Send(mail);
		Debug.Log("success");
	}

	void OnGUI()
	{
		stringToEdit = GUI.TextField(new Rect(235, 173, 200, 20), stringToEdit, 100);
		if (GUI.Button(new Rect(288, 195, 100, 20), "Mandar Email"))
			Email();

		/*GUI.skin.box = style;
		GUILayout.Box(stringToEdit);*/
	}
}