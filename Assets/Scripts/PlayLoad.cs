using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayLoad : MonoBehaviour
{

    public Button b1, b2;
    // Start is called before the first frame update
    void Start()
    {
        Button x = b1.GetComponent<Button>();
        Button y = b2.GetComponent<Button>();
        x.onClick.AddListener(Play);
        y.onClick.AddListener(mainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
