using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter()
	{
		transform.parent.GetComponent<InventoryController> ()._selectedSlot = this.transform;
	}

	void OnMouseExit()
	{
		transform.parent.GetComponent<InventoryController> ()._selectedSlot = null;
	}

}
