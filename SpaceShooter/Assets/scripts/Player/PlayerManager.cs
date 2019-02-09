using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	// 1 = aragon, 2 = penetrator, 3 = swifty,  4 = pancakeor
	public int m_ShipType;
	// 0 = blue , 1 = green, 2 = orange, 3 = red
	public int m_ShipColour;

	public int m_Credits;
	public int m_PlayerID;
	public int m_Difficulty;
	// 0 = attackspeed, 1 = DamageLevel, 2 = armorlevel, 3 = speedlevel, 4 = healthlevel
	public List<int> m_UpgradeLevels;


	// Start is called before the first frame update
	void Start()
    {
		DontDestroyOnLoad(gameObject);
		for (int i = 0; i < 5; i++)
		{
			m_UpgradeLevels.Add(0);
		}
    }
	
	public void GetPlayerStats()
	{
		StartCoroutine(GetShipStats());
	}

	public void SetPlayerStats()
	{
		StartCoroutine(SetShipStats());
	}

	private IEnumerator GetShipStats()
	{
		WWWForm form = new WWWForm();
		form.AddField("playerid", m_PlayerID);
		form.AddField("shiptype", m_ShipType);

		WWW www = new WWW("http://127.0.0.1/edsa-SpaceShooter/getshipstats.php", form);
		yield return www;
		if (www.error != null)
		{
			Debug.LogError("it did not find the file");
		}
		else
		{
			Debug.Log(www.text);
			PlayerStats response = JsonUtility.FromJson<PlayerStats>(www.text);
			
			m_UpgradeLevels[0] = response.attackSpeedLevel;
			m_UpgradeLevels[1] = response.damageLevel;
			m_UpgradeLevels[2] = response.armorLevel;
			m_UpgradeLevels[3] = response.speedLevel;
			m_UpgradeLevels[4] = response.healthLevel;
			m_Credits = response.credits;
			m_Difficulty = response.difficulty;
		}
	}

	private IEnumerator SetShipStats()
	{
		WWWForm form = new WWWForm();
		form.AddField("attackspeedlevel", m_UpgradeLevels[0]);
		form.AddField("damagelevel", m_UpgradeLevels[1]);
		form.AddField("armorlevel", m_UpgradeLevels[2]);
		form.AddField("speedlevel", m_UpgradeLevels[3]);
		form.AddField("healthlevel", m_UpgradeLevels[4]);
		form.AddField("credits", m_Credits);
		form.AddField("difficulty", m_Difficulty);
		form.AddField("playerid", m_PlayerID);
		form.AddField("shiptype", m_ShipType);

		WWW www = new WWW("http://127.0.0.1/edsa-SpaceShooter/setshipstats.php", form);
		yield return www;
		Debug.Log(www.text);
		if (www.error != null)
		{
			Debug.LogError("it did not find the file");
		}
	}

	public void RecieveCredits(float creditAmmount)
	{
		m_Credits += Mathf.RoundToInt(creditAmmount * m_Difficulty);
	}
}

public class PlayerStats
{
	public int attackSpeedLevel;
	public int damageLevel;
	public int armorLevel;
	public int speedLevel;
	public int healthLevel;
	public int credits;
	public int difficulty;
}
