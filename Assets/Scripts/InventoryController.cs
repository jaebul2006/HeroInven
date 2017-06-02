using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour 
{
	public Transform selectedItem, selectedSlot, originalSlot, backGround;

	void Start () 
	{
		
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0) && selectedItem != null)
		{
			originalSlot = selectedItem.parent;
			selectedItem.GetComponent<Collider> ().enabled = false;
		}
		if(Input.GetMouseButton(0) && selectedItem != null)
		{
			selectedItem.position = Input.mousePosition;
			selectedItem.transform.SetParent (backGround);
		}
		else if (Input.GetMouseButtonUp(0) && selectedItem != null)
		{
			//print ("mouse release - selectedSlot is: " + selectedSlot);
			if(selectedSlot == null)
			{
				selectedItem.transform.SetParent (originalSlot);
			}
			else
			{
				selectedItem.transform.SetParent (selectedSlot, false);
			}
			selectedItem.localPosition = Vector3.zero;
			selectedItem.GetComponent<Collider> ().enabled = true;
		}
	}

}
