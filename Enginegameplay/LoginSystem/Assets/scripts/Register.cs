using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Register : MonoBehaviour
{
	[SerializeField] private Text m_Username;
	[SerializeField] private Text m_Email;
	[SerializeField] private Text m_Password;
	[SerializeField] private Text m_ConfirmPassword;
	[SerializeField] private Text m_RegisteredText;

	public void ButtonRegister()
	{
		StartCoroutine(RegisterData());
	}

	public IEnumerator RegisterData()
	{
		WWWForm form = new WWWForm();
		form.AddField("username", m_Username.text);
		form.AddField("email", m_Email.text);
		form.AddField("password", m_Password.text);
		form.AddField("passwordconfirm", m_ConfirmPassword.text);
		WWW www = new WWW("http://127.0.0.1/edsa-Example/unityregister.php", form);
		
		yield return www;
		if (www.error != null)
		{
			Debug.LogError("it did not find the file");
		}
		else
		{
			RegisterResponse response = JsonUtility.FromJson<RegisterResponse>(www.text);
			if (response.success == true)
			{
				m_RegisteredText.text = "Your account has been created!";
			}
			else if (response.success == false && response.incorrect == "username")
			{
				m_RegisteredText.text = "Username is already taken.";
			}
			else if (response.success == false && response.incorrect == "email")
			{
				m_RegisteredText.text = "E-mail has already been used.";
			}
			else if (response.success == false && response.incorrect == "passwordnotsame")
			{
				m_RegisteredText.text = "E-mail has already been used.";
			}
		}
	}
}

[System.Serializable]
public class RegisterResponse
{
	public bool success;
	// false = username true = email
	public string incorrect;
}
