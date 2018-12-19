//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Request : MonoBehaviour {
//	[SerializeField] private TMPro.TextMeshProUGUI m_TextMesh;
//	// Use this for initialization
//	void Start() {

//	}

//	// Update is called once per frame
//	void Update() {
//		if (Input.GetKeyDown(KeyCode.Space))
//		{
//			StartCoroutine(RequestData());
//		}
//	}

//	private IEnumerator RequestData()
//	{
//		WWW www = new WWW ("http://127.0.0.1/edsa-Example/unity.php");
//		yield return www;
//		if( www.error != null)
//		{
//			m_TextMesh.text = www.error;
//		}
//		else
//		{
//			Response response = JsonUtility.FromJson<Response>(www.text);
				
//			string info = response.m_Motd + "\n";
//			for (int i = 0; i < response.m_Scores.Length; i++)
//			{
//				info += response.m_Scores[i].name;
//				info += " ";
//				info += response.m_Scores[i].score.ToString();
//				info += "\n";
//			}
//			m_TextMesh.text = info;
//		}
//	}
//}
//[System.Serializable]
//public class Response
//{
//	public string m_Motd;
//	public Scores[] m_Scores;
//}

//[System.Serializable]
//public class Scores
//{
//	public string name;
//	public int score;
//}
