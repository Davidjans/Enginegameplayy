using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float m_Speed;
	[SerializeField] private bool m_AddforceMovement;
	[SerializeField] private Vector2 m_MaxPositions;
	[SerializeField] private Vector2 m_MinPositions;
	[SerializeField] private float m_MaxVelocity;
	[SerializeField] private float m_MinVelocity;
	private Rigidbody2D m_RigidBody;
	private PlayerManager m_PlayerManager;
	// Start is called before the first frame update
	void Start()
	{
		m_PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
		if(m_PlayerManager.m_UpgradeLevels[3] > 1)
		{
			m_Speed = m_Speed + (m_PlayerManager.m_UpgradeLevels[3] * 50);
		}
		m_RigidBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (m_AddforceMovement == true)
		{
			ForceMove();
		}
		else if (m_AddforceMovement == false)
		{
			StaticMovement();
		}
		FaceMouse(); 
		ScreenTransition();
	}

	private void ForceMove()
	{
		if (Input.GetKey(KeyCode.W))
		{
			m_RigidBody.AddForce(new Vector2(0, m_Speed * Time.deltaTime));
		}
		else if (Input.GetKey(KeyCode.S))
		{
			m_RigidBody.AddForce(new Vector2(0, -m_Speed * Time.deltaTime));
		}
		if (Input.GetKey(KeyCode.A))
		{
			m_RigidBody.AddForce(new Vector2(-m_Speed * Time.deltaTime, 0));
		}
		else if (Input.GetKey(KeyCode.D))
		{
			m_RigidBody.AddForce(new Vector2(m_Speed * Time.deltaTime, 0));
		}
		m_RigidBody.velocity = new Vector3(Mathf.Clamp(m_RigidBody.velocity.x, m_MinVelocity, m_MaxVelocity), Mathf.Clamp(m_RigidBody.velocity.y, m_MinVelocity, m_MaxVelocity), 0);
	}

	private void StaticMovement()
	{
		Vector2 newPosition = transform.position;
		if (Input.GetKey(KeyCode.W))
		{
			newPosition.y = transform.position.y + (m_Speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			newPosition.y = transform.position.y - (m_Speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A))
		{
			newPosition.x = transform.position.x - (m_Speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			newPosition.x = transform.position.x + (m_Speed * Time.deltaTime);
		}
		m_RigidBody.MovePosition(newPosition);
	}

	private void ScreenTransition()
	{
		if (transform.position.x >= m_MaxPositions.x)
		{
			transform.position = new Vector3(m_MinPositions.x + 1, transform.position.y, 0);
		}
		if (transform.position.x <= m_MinPositions.x)
		{
			transform.position = new Vector3(m_MaxPositions.x - 1, transform.position.y, 0);
		}
		if (transform.position.y >= m_MaxPositions.y)
		{
			transform.position = new Vector3(transform.position.x, m_MinPositions.y + 1, 0);
		}
		if (transform.position.y <= m_MinPositions.y)
		{
			transform.position = new Vector3(transform.position.x, m_MaxPositions.y - 1, 0);
		}
	}

	public void FaceMouse()
	{
		Vector3 mouseposition = Input.mousePosition;
		//Debug.Log(mouseposition);
		mouseposition = Camera.main.ScreenToWorldPoint(new Vector3(mouseposition.x,mouseposition.y, 10));
		

		Vector2 direction = new Vector2(mouseposition.x - transform.position.x, mouseposition.y - transform.position.y);
		transform.up = direction;
	}
}
