using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] GameObject deathPrefab;
	[SerializeField] bool destroyOnDeath = true;
	[SerializeField] float maxHealth = 100;
	[SerializeField] bool destroyRoot = false;

	// [HideInInspector] public typically shows in inspector, this attribute hides it.
	// Properties are not exposed to inspector either.
	public float health { get; set; }
	bool isDead = false;

	// Start is called before the first frame update
	void Start()
	{
		health = maxHealth;
	}

	// Update is called once per frame
	public void Damage(float damage)
	{
		health -= damage;
		if (!isDead && health <= 0)
		{
			isDead = true;
			if (TryGetComponent<IDestructable>(out IDestructable destructable))
			{
				destructable.Destroyed();
			}
			if (deathPrefab != null)
			{
				Instantiate(deathPrefab, transform.position, transform.rotation);
			}
			if (destroyOnDeath)
			{
				if (destroyRoot) Destroy(gameObject.transform.root.gameObject);
				else Destroy(gameObject);
			}
		}
	}
}
