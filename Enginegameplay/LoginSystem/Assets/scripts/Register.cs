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


	public void ButtonLogin()
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
			LoginResponse response = JsonUtility.FromJson<LoginResponse>(www.text);

		}
	}
}
