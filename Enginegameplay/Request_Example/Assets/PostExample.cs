using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostExample : MonoBehaviour {
	[SerializeField] private TMPro.TextMeshProUGUI m_TextMesh;
	[SerializeField] private string m_Username;
	[SerializeField] private string m_Password;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(Request());
		}
	}

	private IEnumerator Request()
	{
		WWWForm form = new WWWForm();
		form.AddField("username", m_Username);
		form.AddField("password", m_Password);
		WWW www = new WWW("http://127.0.0.1/edsa-Example/post.php", form);
		yield return www;
		if(www.error != null)
		{
			m_TextMesh.text = www.error;
		}
		else
		{
			m_TextMesh.text = www.text;
		}
	}
}
