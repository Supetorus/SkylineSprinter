using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] Item[] items; // can possibly have

	public Item ActiveItem { get; set; }
	int itemIndex = 0;

	List<Item> inventory = new List<Item>(); // On our person

	// Start is called before the first frame update
	void Start()
	{
		//inventory.AddRange(items);
		inventory.Add(null);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if (itemIndex >= inventory.Count()) itemIndex = 0;
			ActivateItem(inventory[itemIndex]);
		};
		//if (Input.GetKeyDown(KeyCode.Alpha1)) ActivateItem(null);
		//if (Input.GetKeyDown(KeyCode.Alpha2)) ActivateItem(inventory[0]);
		//if (Input.GetKeyDown(KeyCode.Alpha3)) ActivateItem(inventory[1]);
		ActiveItem?.UpdateItem();
	}
	public bool AddItem(Item.Type type)
	{
		if (HasType(type)) return false;
		
		var item = items.Where(x => x.type == type).FirstOrDefault();

		inventory.Add(item);

		return true;
	}

	public bool HasType(Item.Type type)
	{
		return inventory.Any(i => i?.type == type);
	}

	void ActivateItem(Item item)
	{
		ActiveItem?.Deactivate();

		ActiveItem = item;

		item?.Activate();
	}

	public void StartItem()
	{
		if (ActiveItem is Weapon weapon)
		{
			weapon.Fire();
		}
	}
}
