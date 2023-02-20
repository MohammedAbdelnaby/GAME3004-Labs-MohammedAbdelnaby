using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathVoid : MonoBehaviour
{
    [SerializeField]
    private Transform SpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Respawn(other.gameObject);
        }
    }

    public  void Respawn(GameObject obj)
    {
        obj.transform.position = SpawnPoint.position;
        Debug.Log("Hit");
    }
}