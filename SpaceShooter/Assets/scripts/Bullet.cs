﻿	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float m_Damage;
	private float m_Timer = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		m_Timer -= Time.deltaTime;
		if(m_Timer <= 0)
		{
			Destroy(gameObject);
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.CompareTag("Enemy"))
		{
			Debug.Log("enemy been hit");
			collision.GetComponent<Enemy>().TakeDamage(m_Damage);
			Destroy(gameObject);
		}
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<Player>().TakeDamage(m_Damage);
			Destroy(gameObject);
		}
	}
}
