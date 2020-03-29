using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("function called");
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Complete");
        }
    }
}
