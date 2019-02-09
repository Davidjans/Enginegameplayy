using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float m_Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<Enemy>().TakeDamage(m_Damage);
		}
		if (other.CompareTag("Player"))
		{
			other.GetComponent<Player>().TakeDamage(m_Damage);
		}
	}
}
