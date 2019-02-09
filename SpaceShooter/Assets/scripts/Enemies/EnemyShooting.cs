using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
	[SerializeField] private float m_OriginalReloadTimer;
	[SerializeField] private GameObject m_BulletPrefab;
	[SerializeField] private Transform m_Origin;
	[SerializeField] private float m_BulletSpeed;
	[SerializeField] private float m_Damage;

	private PlayerManager m_PlayerManager;
	public float m_CurrentReloadTimer;
	// Start is called before the first frame update
	void Start()
	{
		m_PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
		m_CurrentReloadTimer = m_OriginalReloadTimer;
	}

	// Update is called once per frame
	void Update()
	{
		m_CurrentReloadTimer -= Time.deltaTime;
		if (m_CurrentReloadTimer <= 0)
		{
			GameObject bullet;
			bullet = Instantiate(m_BulletPrefab, m_Origin.position, m_Origin.rotation);
			bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * m_BulletSpeed, ForceMode2D.Impulse);
			bullet.GetComponent<Bullet>().m_Damage = m_Damage * (m_PlayerManager.m_Difficulty * (m_Damage * 0.5f));
			m_CurrentReloadTimer = m_OriginalReloadTimer;
		}
	}
}
