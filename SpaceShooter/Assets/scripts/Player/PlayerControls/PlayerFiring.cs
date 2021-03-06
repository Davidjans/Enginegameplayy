﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
	[SerializeField] private float m_OriginalReloadTimer;
	[SerializeField] private List<GameObject> m_BulletPrefabs;
	[SerializeField] private Transform m_Origin;
	[SerializeField] private float m_BulletSpeed;
	[SerializeField] private float m_Damage;

	private PlayerManager m_PlayerManager;
	public float m_CurrentReloadTimer;
    // Start is called before the first frame update
    void Start()
    {
		m_PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
		m_OriginalReloadTimer -= (m_PlayerManager.m_UpgradeLevels[0] * 0.025f);
		m_CurrentReloadTimer = m_OriginalReloadTimer;
		
    }

    // Update is called once per frame
    void Update()
    {
		m_CurrentReloadTimer -= Time.deltaTime;
		if(m_CurrentReloadTimer <= 0)
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameObject bullet;
				if (m_PlayerManager.m_UpgradeLevels[1] <= 5)
				{
					bullet = Instantiate(m_BulletPrefabs[0], m_Origin.position, m_Origin.rotation);
				}
				else if (m_PlayerManager.m_UpgradeLevels[1] > 5 && m_PlayerManager.m_UpgradeLevels[1] <= 10)
				{
					bullet = Instantiate(m_BulletPrefabs[1], m_Origin.position, m_Origin.rotation);
				}
				else if (m_PlayerManager.m_UpgradeLevels[1] > 10)
				{
					bullet = Instantiate(m_BulletPrefabs[2], m_Origin.position, m_Origin.rotation);
				}
				else
				{
					bullet = Instantiate(m_BulletPrefabs[0], m_Origin.position, m_Origin.rotation);
				}
				bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * m_BulletSpeed, ForceMode2D.Impulse);
				bullet.GetComponent<Bullet>().m_Damage = m_Damage * (m_PlayerManager.m_UpgradeLevels[1] * (m_Damage * 0.5f));
				m_CurrentReloadTimer = m_OriginalReloadTimer;
			}
		}
    }
}
