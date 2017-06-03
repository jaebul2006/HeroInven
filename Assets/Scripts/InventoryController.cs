using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour 
{
	public Transform _selectedItem, _selectedSlot, _originalSlot, _backGround;
	public GameObject _slotPrefab, _itemPrefab;
	public Vector2 _inventorySize = new Vector2(4, 6);
	public float _slotSize;
	public Vector2 _windowSize;
	public bool _canDragItem = false;

	void Start () 
	{
		for (int x = 1; x <= _inventorySize.x; x++) {
			for (int y = 1; y <= _inventorySize.y; y++) {
				GameObject slot = Instantiate (_slotPrefab) as GameObject;
				slot.transform.SetParent (this.transform);
				slot.name = "slot_" + x + "_" + y;
				slot.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (_windowSize.x/(_inventorySize.x+1)*x, _windowSize.y/(_inventorySize.y+1)*-y, 0f);

				if((x + (y-1) * 4) <= GameDB._itemList.Count){
					GameObject item = Instantiate (_itemPrefab) as GameObject;
					item.transform.SetParent (slot.transform);
					item.GetComponent<RectTransform> ().anchoredPosition = Vector3.zero;
					Item i = item.GetComponent<Item> ();
					i._name = GameDB._itemList [(x + (y - 1) * 4)-1]._name;
					i._type = GameDB._itemList [(x + (y - 1) * 4)-1]._type;
					i._sprite = GameDB._itemList [(x + (y - 1) * 4)-1]._sprite;
					item.name = i._name;
					item.GetComponent<Image> ().sprite = i._sprite;
				}
			}
		}	
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0) && _selectedItem != null)
		{
			_canDragItem = true;
			_originalSlot = _selectedItem.parent;
			_selectedItem.GetComponent<Collider> ().enabled = false;
			SetItemsColliders (false);
		}

		if(Input.GetMouseButton(0) && _selectedItem != null && _canDragItem)
		{
			_selectedItem.position = Input.mousePosition;
			_selectedItem.transform.SetParent (_backGround);
		}
		else if (Input.GetMouseButtonUp(0) && _selectedItem != null)
		{
			_canDragItem = false;
			SetItemsColliders (true);
			//print ("mouse release - selectedSlot is: " + selectedSlot);
			if(_selectedSlot == null)
			{
				_selectedItem.SetParent (_originalSlot);
			}
			else
			{
				if (_selectedSlot.childCount != 0) {
					_selectedSlot.GetChild (0).parent = _originalSlot;
				}
				_selectedItem.SetParent (_selectedSlot);
			}
			if (_originalSlot.childCount != 0) {
				_originalSlot.GetChild (0).localPosition = Vector3.zero;
			}
			_selectedItem.localPosition = Vector3.zero;
			_selectedItem.GetComponent<Collider> ().enabled = true;
		}
	}

	void SetItemsColliders(bool b)
	{
		foreach(GameObject item in GameObject.FindGameObjectsWithTag("Item"))
		{
			item.GetComponent<Collider> ().enabled = b;
		}
	}

}
