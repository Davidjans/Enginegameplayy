using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterSelection : MonoBehaviour
{
	
	[SerializeField] private Dropdown m_DropDown;
	[SerializeField] private Image m_Image;
	[SerializeField] private GameObject m_TypeSelector;
	[SerializeField] private GameObject m_ColorSelector;

	private PlayerManager m_PlayerManager;

	private void Start()
	{
		m_PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
	}

	public void ShipTypeSelect(int shipType)
	{
		
		m_PlayerManager.m_ShipType = shipType;
		m_ColorSelector.SetActive(true);
		ColorChange();
		m_PlayerManager.GetPlayerStats();
		m_TypeSelector.SetActive(false);
	}

	public void ColorChange()
	{
		if(m_PlayerManager.m_ShipType == 1)
		{
			AragonColorChange();
		}
		if (m_PlayerManager.m_ShipType == 2)
		{
			PenetratorColorChange();
		}
		if (m_PlayerManager.m_ShipType == 3)
		{
			SwiftyColorChange();
		}
		if (m_PlayerManager.m_ShipType == 4)
		{
			PancakeorColorChange();
		}
		m_PlayerManager.m_ShipColour = m_DropDown.value;
	}

	public void switchScenes()
	{
		SceneManager.LoadScene("UpgradeMenu");
	}


	private void AragonColorChange()
	{
		if (m_DropDown.value == 0)
		{
			m_Image.sprite = Resources.Load<Sprite>("Aragon_blue");
		}
		else if (m_DropDown.value == 1)
		{
			m_Image.sprite = Resources.Load<Sprite>("Aragon_green");
		}
		else if (m_DropDown.value == 2)
		{
			m_Image.sprite = Resources.Load<Sprite>("Aragon_orange");
		}
		else if (m_DropDown.value == 3)
		{
			m_Image.sprite = Resources.Load<Sprite>("Aragon_red");
		}
	}

	private void PenetratorColorChange()
	{
		if (m_DropDown.value == 0)
		{
			m_Image.sprite = Resources.Load<Sprite>("Penetrator_blue");
		}
		else if (m_DropDown.value == 1)
		{
			m_Image.sprite = Resources.Load<Sprite>("Penetrator_green");
		}
		else if (m_DropDown.value == 2)
		{
			m_Image.sprite = Resources.Load<Sprite>("Penetrator_orange");
		}
		else if (m_DropDown.value == 3)
		{
			m_Image.sprite = Resources.Load<Sprite>("Penetrator_red");
		}
	}

	private void SwiftyColorChange()
	{
		if (m_DropDown.value == 0)
		{
			m_Image.sprite = Resources.Load<Sprite>("Swifty_blue");
		}
		else if (m_DropDown.value == 1)
		{
			m_Image.sprite = Resources.Load<Sprite>("Swifty_green");
		}
		else if (m_DropDown.value == 2)
		{
			m_Image.sprite = Resources.Load<Sprite>("Swifty_orange");
		}
		else if (m_DropDown.value == 3)
		{
			m_Image.sprite = Resources.Load<Sprite>("Swifty_red");
		}
	}

	private void PancakeorColorChange()
	{
		if (m_DropDown.value == 0)
		{
			m_Image.sprite = Resources.Load<Sprite>("Pancakeor_blue");
		}
		else if (m_DropDown.value == 1)
		{
			m_Image.sprite = Resources.Load<Sprite>("Pancakeor_green");
		}
		else if (m_DropDown.value == 2)
		{
			m_Image.sprite = Resources.Load<Sprite>("Pancakeor_orange");
		}
		else if (m_DropDown.value == 3)
		{
			m_Image.sprite = Resources.Load<Sprite>("Pancakeor_red");
		}
	}

	

}
