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
	public Texture btnTexture;
	bool email = false;

	void Update()
	{
		if(email)
		{
			MailMessage mail = new MailMessage();
			
			mail.From = new MailAddress(stringToEdit);
			mail.To.Add(stringToEdit);
			mail.Subject = "Test Mail";
			mail.Body = "Consegui";
			
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
	}

	void OnGUI()
	{
		stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 100);
		if (GUI.Button(new Rect(75, 30, 50, 20), btnTexture))
			email = true;

		GUI.skin.box = style;
		GUILayout.Box(stringToEdit);
	}
}