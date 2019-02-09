using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
	public int m_EnemyAmmount;
	public int m_CurrentWave;
	[SerializeField] private List<GameObject> m_AragonPrefabs;
	[SerializeField] private List<GameObject> m_PenetratorPrefabs;
	[SerializeField] private List<GameObject> m_SwiftyPrefabs;
	[SerializeField] private List<GameObject> m_PancakeorPrefabs;
	

	private PlayerManager m_PlayerManager;
	// Start is called before the first frame update
	void Start()
    {
		m_PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
		if(m_PlayerManager.m_ShipType == 1)
		{
			Instantiate(m_AragonPrefabs[m_PlayerManager.m_ShipColour], transform.position, transform.rotation);
		}
		else if (m_PlayerManager.m_ShipType == 2)
		{
			Instantiate(m_PenetratorPrefabs[m_PlayerManager.m_ShipColour], transform.position, transform.rotation);
		}
		else if (m_PlayerManager.m_ShipType == 3)
		{
			Instantiate(m_SwiftyPrefabs[m_PlayerManager.m_ShipColour], transform.position, transform.rotation);
		}
		else if (m_PlayerManager.m_ShipType == 4)
		{
			Instantiate(m_PancakeorPrefabs[m_PlayerManager.m_ShipColour], transform.position, transform.rotation);
		}
	}
}
