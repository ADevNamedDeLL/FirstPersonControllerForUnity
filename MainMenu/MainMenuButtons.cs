using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
MADE BY : ADevNamedDeLL
Be sure to Subscribe to my YouTube Channel
*/

public class MainMenuButtons : MonoBehaviour
{
    [Header("Canvases")]
    [SerializeField] private GameObject MainCanvas;
    [SerializeField] private GameObject OptionsCanvas;

    [Header("Buttons")]
    [SerializeField] private Button StartB;
    [SerializeField] private Button OptionsB;
    [SerializeField] private Button ExitB;
    [SerializeField] private Button Back2MenuB;

    [Header("NameOfStartScene")]
    [SerializeField] private string SceneName;

    private void Start()
    {
        MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);

        if (StartB != null)
        {
            StartB.onClick.AddListener(StartGame);
        }

        if (OptionsB != null)
        {
            OptionsB.onClick.AddListener(OptionsFunc);
        }

        if (ExitB != null)
        {
            ExitB.onClick.AddListener(QuitGame);
        }

        if (Back2MenuB != null)
        {
            Back2MenuB.onClick.AddListener(Back2MenuFunc);
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene(SceneName);
        Debug.Log("Starting Game ...");
    }

    void OptionsFunc()
    {
        MainCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }

    void Back2MenuFunc()
    {
        MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game ...");
    }
}
