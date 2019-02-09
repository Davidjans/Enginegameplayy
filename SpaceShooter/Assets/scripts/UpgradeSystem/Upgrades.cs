using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI m_Credits;
	[SerializeField] private TextMeshProUGUI m_Difficulty;
	[SerializeField] private List<TextMeshProUGUI> m_UpgradeLevels;
	[SerializeField] private List<TextMeshProUGUI> m_UpgradeCosts;
	[SerializeField] private List<Button> m_UpgradeButtons;
	
	private PlayerManager m_PlayerManager;
	// Start is called before the first frame update
	void Start()
	{
		m_PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
	}

	// Update is called once per frame
	void Update()
	{
		m_Credits.text = m_PlayerManager.m_Credits.ToString();
		m_Difficulty.text = m_PlayerManager.m_Difficulty.ToString();
		for (int i = 0; i < m_PlayerManager.m_UpgradeLevels.Count; i++)
		{
			m_UpgradeLevels[i].text = m_PlayerManager.m_UpgradeLevels[i].ToString();
			float upgradeCost = m_PlayerManager.m_UpgradeLevels[i] * 250;
			m_UpgradeCosts[i].text = upgradeCost.ToString(); 
		}

		for (int i = 0; i < m_PlayerManager.m_UpgradeLevels.Count; i++)
		{
			if(m_PlayerManager.m_Credits >= (m_PlayerManager.m_UpgradeLevels[i] * 250))
			{
				m_UpgradeButtons[i].gameObject.SetActive(true);
			}
			else
			{
				m_UpgradeButtons[i].gameObject.SetActive(false);
			}
		}
	}

	public void IncreaseDifficulty()
	{
		m_PlayerManager.m_Difficulty += 1;
		m_PlayerManager.m_Difficulty = Mathf.Clamp(m_PlayerManager.m_Difficulty, 1, 2000);
	}
	public void DecreaseDifficulty()
	{
		m_PlayerManager.m_Difficulty -= 1;
		m_PlayerManager.m_Difficulty = Mathf.Clamp(m_PlayerManager.m_Difficulty, 1, 2000);
	}

	public void UpgradeStats(int chosenupgrade)
	{
		if(m_PlayerManager.m_Credits >= m_PlayerManager.m_UpgradeLevels[chosenupgrade] * 250)
		{
			m_PlayerManager.m_Credits -=m_PlayerManager.m_UpgradeLevels[chosenupgrade] * 250;
			m_PlayerManager.m_UpgradeLevels[chosenupgrade] += 1;
		}
	}
}
