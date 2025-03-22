using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroywall : MonoBehaviour
{
    [Header("Walls to Disable")]
    [SerializeField] private List<GameObject> walls = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DisableWalls();
        }
    }

    private void DisableWalls()
    {
        foreach (var wall in walls)
        {
            if (wall != null)
            {
                wall.SetActive(false);
            }
        }
    }
}
