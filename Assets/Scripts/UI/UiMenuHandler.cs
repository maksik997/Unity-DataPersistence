using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UiMenuHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BestScoreText;
    [SerializeField] private TMP_InputField NameText;

    void Start()
    {
        if (Persistance.Instance != null)
        {
            BestScoreText.text = $"Best Score : {Persistance.Instance.PlayerName} : {Persistance.Instance.Score}";
            NameText.text = Persistance.Instance.PlayerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        // This method will start the app
        SceneManager.LoadScene(1);
    }

    public void QuitApp()
    {
        // This method will stop the app
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
