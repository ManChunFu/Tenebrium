using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;

    private void Awake()
    {
        if (gameManager == null)
            FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameManager.ResumeGame();
    }
}
