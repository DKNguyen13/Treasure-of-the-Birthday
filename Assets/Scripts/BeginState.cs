using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginState : MonoBehaviour
{
    public Button b1,b2;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1180, 720, false);
        Button  x = b1.GetComponent<Button>();
        x.onClick.AddListener(TaskOnClick);
        Button y = b2.GetComponent<Button>();
        y.onClick.AddListener(TaskOnClick1);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            exitGame();
        }
    }
    public void TaskOnClick()
    {
        SceneManager.LoadScene(1);
    }
    void TaskOnClick1()
    {
        //Debug.Log("You have clicked the button!");
        exitGame();
    }
    void exitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
