using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
	[SerializeField] private Text m_LoginNameText;
	[SerializeField] private Text m_LoginPasswordText;
	[SerializeField] private Text m_Loggedin;
	[SerializeField] private Text m_Token;
	[SerializeField] private PlayerManager m_PlayerManager;

	public void ButtonLogin()
	{
		StartCoroutine(LoginData());
	}

	private IEnumerator LoginData()
	{
		WWWForm form = new WWWForm();
		form.AddField("loginName", m_LoginNameText.text);
		form.AddField("password", m_LoginPasswordText.text);

		WWW www = new WWW("http://127.0.0.1/edsa-SpaceShooter/unitylogin.php", form);
		yield return www;
		if (www.error != null)
		{
			Debug.LogError("it did not find the file");
		}
		else
		{
			Debug.Log(www.text);
			LoginResponse response = JsonUtility.FromJson<LoginResponse>(www.text);
			if (response.success == true)
			{
				m_PlayerManager.m_PlayerID = response.playerid;
				SceneManager.LoadScene("CharacterSelect");
			}
			else if(response.success == false && response.incorrect == false)
			{
				m_Loggedin.text = "Login failed. Password incorrect";
			}
			else if (response.success == false && response.incorrect == true)
			{
				m_Loggedin.text = "Login failed. Username incorrect";
			}
			else
			{
				Debug.Log("Autism");
			}
			//string info = response. + "\n";

			//m_TextMesh.text = info;
		}
	}
}
[System.Serializable]
public class LoginResponse
{
	public bool success;
	public string token;
	// false = password true	= username
	public bool incorrect;
	public int playerid;
}
