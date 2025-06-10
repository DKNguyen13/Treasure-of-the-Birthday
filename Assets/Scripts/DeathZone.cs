using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private UIManager _manager;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<UIManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _manager.showGameoverPanel();
            audioManager.StopMusic(audioManager.lose);
            Destroy(gameObject);
        }
    }
}
