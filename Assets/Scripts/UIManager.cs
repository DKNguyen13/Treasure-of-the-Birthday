using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameoverPanel;
    public TextMeshProUGUI wintext, loseText;
    // Start is called before the first frame update
    public void showGameoverPanel()
    {
        if(gameoverPanel != null)
        {
            gameoverPanel.SetActive(true);
            wintext.enabled = false;
            loseText.enabled = true;
        }
    }
    public void hideGameoverPanel()
    {
        if( gameoverPanel != null )
        {
            gameoverPanel.SetActive(false);
        }
    }
}
