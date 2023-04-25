using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class PlayFabManager : MonoBehaviour
{
    [SerializeField] GameObject rowPrefab;
    [SerializeField] Transform rowsParent;
    [SerializeField] TextMeshProUGUI tittleText;
    [SerializeField] TMP_InputField emailInput;
    [SerializeField] TMP_InputField passwordInput;
    [SerializeField] Button registerButton;
    [SerializeField] Button resetPasswordButton;
    [SerializeField] Button loginButton;
    [SerializeField] GameObject loginBox;
    [SerializeField] TMP_InputField nickNameInput;
    [SerializeField] Button submitNickNameButton;
    SliderGroup mySliderGroup;

    void Awake()
    {
        mySliderGroup = FindObjectOfType<SliderGroup>();
    }

    void Start()
    {
        if (registerButton)
        {
            registerButton.onClick.AddListener(RegisterButton);
        }
        if (loginButton)
        {
            loginButton.onClick.AddListener(LoginButton);
        }
        if (resetPasswordButton)
        {
            resetPasswordButton.onClick.AddListener(ResetPasswordButton);
        }
        if (submitNickNameButton)
        {
            submitNickNameButton.onClick.AddListener(SubmitNickNameButton);
        }
    }

    void OnSuccess(LoginResult result)
    {
        string nickName = null;
        if (result.InfoResultPayload.PlayerProfile != null)
        {
            nickName = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        if (nickName == null)
        {
            loginBox.SetActive(false);
            nickNameInput.gameObject.SetActive(true);
            submitNickNameButton.gameObject.SetActive(true);
        }
        else
        {
            GetPlayerData();
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    void OnError(PlayFabError error)
    {
        if (tittleText)
        {
            tittleText.text = error.ErrorMessage;
        }
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderBoard(int score)
    {
        Debug.Log("SendLeaderBoard");
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "CatScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Success leaderboard sent");
        SavePlayerData();
    }

    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "CatScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }

    void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject instance = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] texts = instance.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }

    void RegisterButton()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        tittleText.text = "Conta criada e conectada!";
    }

    void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
    }

    void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "AA231"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        tittleText.text = "Password reset email sent!";
    }

    void SubmitNickNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nickNameInput.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        LoadNextScene();
    }

    void GetPlayerData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    void OnDataReceived(GetUserDataResult result)
    {
        Debug.Log("Received data");
        if (result.Data != null &&
            result.Data.ContainsKey("CatAmount") &&
            result.Data.ContainsKey("MoneyAmount") &&
            result.Data.ContainsKey("SliderGroup"))
        {
            Debug.Log("Successful data");
            FindObjectOfType<CatCounter>().ChangeCatAmount(int.Parse(result.Data["CatAmount"].Value));
            FindObjectOfType<MoneyCounter>().ChangeMoneyAmount(int.Parse(result.Data["MoneyAmount"].Value));
            CatSpawner catSpawner = FindObjectOfType<CatSpawner>();
            for (int i = 0; i < int.Parse(result.Data["CatAmount"].Value); i++)
            {
                catSpawner.InstantiateCat();
            }
            mySliderGroup.SetSliderGroup(JsonConvert.DeserializeObject<SliderGroupValues>(result.Data["SliderGroup"].Value));
        }
        else
        {
            Debug.Log("Data corrupted");
        }
    }

    void SavePlayerData()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"CatAmount", FindObjectOfType<CatCounter>().CatAmount.ToString()},
                {"MoneyAmount", FindObjectOfType<MoneyCounter>().MoneyAmount.ToString()},
                {"SliderGroup", JsonConvert.SerializeObject(mySliderGroup.ReturnClass())}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Success data sent");
    }
}
