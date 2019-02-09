using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float m_MaxHealth;
	[SerializeField] private float m_Damage;
	[SerializeField] private float m_Speed;

	private float m_Health;
	private PlayerManager m_PlayerManager;
	private MatchManager m_MatchManager;
    // Start is called before the first frame update
    void Start()
    {
		m_PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
		m_MatchManager = GameObject.Find("MatchManager").GetComponent<MatchManager>();
		m_MaxHealth = m_MaxHealth * m_PlayerManager.m_Difficulty;
		m_Health = m_MaxHealth;
		m_Damage = m_Damage * m_PlayerManager.m_Difficulty;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void TakeDamage(float damage)
	{
		m_Health -= damage;
		if(m_Health <= 0)
		{
			m_MatchManager.m_EnemyAmmount--;
			m_PlayerManager.RecieveCredits(Random.Range(10, 25));
			
			Destroy(gameObject);
		}
	}
}
