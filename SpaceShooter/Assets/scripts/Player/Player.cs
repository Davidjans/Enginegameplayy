using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
	[SerializeField] private float m_MaxHealth;


	private float m_CurrentHealth = 1;

	private TextMeshProUGUI m_HealthDisplay;
	private PlayerManager m_PlayerManager;
	// Start is called before the first frame update
	void Start()
	{
		m_PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
		m_MaxHealth = m_MaxHealth * m_PlayerManager.m_UpgradeLevels[4];
		m_CurrentHealth = m_MaxHealth;
		m_HealthDisplay = GameObject.Find("CurrentHealth").GetComponent<TextMeshProUGUI>();
		UpdateHealth();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			TakeDamage(99999999);
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			m_PlayerManager.m_Credits += 9999;
		}
	}

	public void TakeDamage(float damage)
	{
		damage -= m_PlayerManager.m_UpgradeLevels[2] * 2;
		m_CurrentHealth -= damage;
		UpdateHealth();
		if (m_CurrentHealth <= 0)
		{
			m_PlayerManager.SetPlayerStats();
			SceneManager.LoadScene("UpgradeMenu");
		}
	}

	private void UpdateHealth()
	{
		m_HealthDisplay.text = m_CurrentHealth.ToString() + " / " + m_MaxHealth.ToString();
	}
}
