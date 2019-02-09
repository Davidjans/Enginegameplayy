using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	PlayerManager m_PlayerManager;
	private void Start()
	{
		m_PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
	}
	public void SwitchScenes(string SceneToSwitchTo)
	{
		m_PlayerManager.SetPlayerStats();
		SceneManager.LoadScene(SceneToSwitchTo);
	}
}
