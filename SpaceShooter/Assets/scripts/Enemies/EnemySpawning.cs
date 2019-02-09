using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
	[SerializeField] private List<GameObject> m_Enemies;
	[SerializeField] private List<Transform> m_SpawnPoints;
	[SerializeField] private MatchManager m_MatchManager;

    // Update is called once per frame
    void Update()
    {
        if(m_MatchManager.m_EnemyAmmount <= 0)
		{
			EnemySpawner();
		}
    }

	private void EnemySpawner()
	{
		for (int i = 0; i < m_MatchManager.m_CurrentWave; i++)
		{
			GameObject enemy = Instantiate(m_Enemies[Random.Range(0, m_Enemies.Count)], m_SpawnPoints[Random.Range(0, m_SpawnPoints.Count)].position, m_SpawnPoints[Random.Range(0, m_SpawnPoints.Count)].rotation);
			m_MatchManager.m_EnemyAmmount++;
		}
		m_MatchManager.m_CurrentWave++;
	}
}
