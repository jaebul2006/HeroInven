using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDB : MonoBehaviour {

	public Sprite[] _sprites;
	public static List<Item>_itemList = new List<Item>();

	// Use this for initialization
	void Start () {
		Item i0 = new Item ();
		i0._name = "Arrow Quiver 1";
		i0._type = Item.Type.equip;
		i0._sprite = _sprites [0];
		_itemList.Add (i0);

		Item i1 = new Item ();
		i1._name = "Arrow Quiver 2";
		i1._type = Item.Type.equip;
		i1._sprite = _sprites [1];
		_itemList.Add (i1);

		Item i2 = new Item ();
		i2._name = "Axe A 1";
		i2._type = Item.Type.equip;
		i2._sprite = _sprites [2];
		_itemList.Add (i2);

		Item i3 = new Item ();
		i3._name = "Axe A 2";
		i3._type = Item.Type.equip;
		i3._sprite = _sprites [3];
		_itemList.Add (i3);

		Item i4 = new Item ();
		i4._name = "Axe A 3";
		i4._type = Item.Type.equip;
		i4._sprite = _sprites [4];
		_itemList.Add (i4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
