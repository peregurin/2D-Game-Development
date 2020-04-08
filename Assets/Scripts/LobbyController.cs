using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(loadPopUp);
    }

    public void loadPopUp()
    {
        LevelSelection.SetActive(true);
    }

    public void loadFirstLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
