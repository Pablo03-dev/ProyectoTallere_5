using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyHP : MonoBehaviour
{
	//Para usar en balas para matar enemigos

	//public bool destroyWhenActivated = false;
	public int healthChange = -1;

	private void OnCollisionEnter(Collision collisionData)
	{
		OnCollisionEnter(collisionData.collider);
	}

	private void OnCollisionEnter(Collider colliderData)
	{
		HPSystem healthScript = colliderData.gameObject.GetComponent<HPSystem>();
		if (healthScript != null)
		{
			healthScript.ModifyHealth(healthChange);

			//if (destroyWhenActivated)
			//{
			//	Destroy(this.gameObject);
			//}
		}

        if (colliderData.gameObject.tag == "Piso")
        {
            Destroy(gameObject);
        }

	}
}
