using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float m_MaxHealth;
	[SerializeField] private float m_Damage;
	[SerializeField] private float m_Speed;
	private PlayerManager m_PlayerManager;
    // Start is called before the first frame update
    void Start()
    {
		m_PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
		m_MaxHealth = m_MaxHealth * m_PlayerManager.m_Difficulty;
		m_Damage = m_Damage * m_PlayerManager.m_Difficulty;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
