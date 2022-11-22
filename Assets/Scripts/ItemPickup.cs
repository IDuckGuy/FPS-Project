using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
  void OnTriggerEnter(Collider other)
  {
      if(other.CompareTag("Health Item"))
      {
          Debug.Log("Health Item picked up");
          //add health here
          gameObject.GetComponent<PlayerHealth>().playerHealth += 50f;
          Destroy(other.gameObject);
      }
  }
  void OnTriggerStay(Collider other)
  {
      if(other.CompareTag("Ammo Item") && Input.GetKeyDown("KeyCode.E"))
      {
          Debug.Log("Ammo Item picked up");
      }
  }
}
