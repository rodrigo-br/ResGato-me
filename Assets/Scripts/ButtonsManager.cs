using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] Button workButton;
    [SerializeField] Button storeButton;
    [SerializeField] Button otherButton;
    [SerializeField] Canvas leaderBoardCanvas;
    MoneyCounter moneyCounter;

    void Awake()
    {
        moneyCounter = FindObjectOfType<MoneyCounter>();
        if (workButton)
        {
            workButton.onClick.AddListener(WorkButton);
        }
        if (storeButton)
        {
            storeButton.onClick.AddListener(EnterStore);
        }
        if (otherButton)
        {
            otherButton.onClick.AddListener(ShowLeaderBoard);
        }
    }

    void WorkButton()
    {
        moneyCounter.Work();
    }

    void EnterStore()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "MainScene")
        {
            SceneManager.LoadScene("StoreScene");
            FindObjectOfType<CatSpawner>().gameObject.SetActive(false);
        }
        else if (activeScene == "StoreScene")
        {
            SceneManager.LoadScene("MainScene");
            FindObjectOfType<CatSpawner>(true).gameObject.SetActive(true);
        }
    }

    void ShowLeaderBoard()
    {
        if (leaderBoardCanvas)
        {
            leaderBoardCanvas.enabled = !leaderBoardCanvas.enabled;
            FindObjectOfType<PlayFabManager>()?.GetLeaderBoard();
        }
    }
}
