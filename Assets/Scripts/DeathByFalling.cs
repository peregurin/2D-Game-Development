using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathByFalling : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("DEATH , restart level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
