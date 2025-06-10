using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer m_Renderer;
    [SerializeField] private float speed;
    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Renderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime,0);
    }
}
