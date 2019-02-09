using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float m_RotationSpeed = 90;
	[SerializeField] private float m_Speed = 5f;

	private Rigidbody2D m_RigidBody;
	Transform m_player;

    // Start is called before the first frame update
    void Start()
    {
		m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		m_RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 direction = m_player.position - transform.position;

		direction.Normalize();

		float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

		Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);

		transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, m_RotationSpeed * Time.deltaTime);

		Vector3 position = transform.position;
		Vector3 velocity = new Vector3(0, m_Speed * Time.deltaTime, 0);
		position += transform.rotation * velocity;

		transform.position = position;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Player player = collision.gameObject.GetComponent<Player>();
			player.TakeDamage(5 * GameObject.Find("PlayerManager").GetComponent<PlayerManager>().m_Difficulty);
			Destroy(gameObject);
		}
	}
}
