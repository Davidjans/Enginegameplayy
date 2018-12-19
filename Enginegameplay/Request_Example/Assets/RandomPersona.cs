using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPersona : MonoBehaviour {
	[SerializeField] private TMPro.TextMeshProUGUI m_TextMesh;
	[SerializeField] private int m_PersonaAmount;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(RequestData());
		}
	}

	private IEnumerator RequestData()
	{
		WWWForm form = new WWWForm();
		form.AddField("PersonaAmmount", m_PersonaAmount);
		WWW www = new WWW("http://127.0.0.1/edsa-Example/randompersona.php", form);
		
		yield return www;
		if (www.error != null)
		{
			m_TextMesh.text = www.error;
		}
		else
		{
			Response response = JsonUtility.FromJson<Response>(www.text);
			string info = string.Empty;
			for (int i = 0; i < response.persons.Length; i++)
			{
				info += response.persons[i].firstName;
				info += " ";
				info += response.persons[i].lastName;
				info += "\n";
			}
			m_TextMesh.text = info;
		}
	}
}
[System.Serializable]
public class Response
{
	public Persons[] persons;
}

[System.Serializable]
public class Persons
{
	public string firstName;
	public string lastName;
}
