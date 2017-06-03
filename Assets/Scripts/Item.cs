using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public string _name;
	public enum Type
	{
		equip,
		consumable,
		misc
	}
	public Type _type;
	public Sprite _sprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter()
	{
		transform.parent.parent.GetComponent<InventoryController> ()._selectedItem = this.transform;
	}

	void OnMouseExit()
	{
//		if (!transform.parent.parent.GetComponent<InventoryController> ()._canDragItem) {
//			transform.parent.parent.GetComponent<InventoryController> ()._selectedItem = null;
//		}

		if (!GameObject.Find ("Inventory").GetComponent<InventoryController> ()._canDragItem) {
			GameObject.Find ("Inventory").GetComponent<InventoryController> ()._selectedItem = null;
		}
	}

}

