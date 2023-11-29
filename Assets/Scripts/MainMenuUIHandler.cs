using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class MainMenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerName;

    protected string player;

    private void Start()
    {
        playerName = GameObject.Find("Name").GetComponent<TMP_InputField>();
        playerName.onEndEdit.AddListener(delegate { SaveName(playerName.text); });
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        PlayerStatistics.Instance.LoadData();
    }

    public void ExitApplication()
    {
        #if (UNITY_EDITOR)
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void SaveName(string name)
    {
        PlayerStatistics.Instance.currentPlayer = name;
    }
}