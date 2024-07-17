using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winUI;

    public ItemBox[] itemBoxes;
    public bool isGameOver;

    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }

        if (isGameOver == true)
        {
            return;
        }

        int count = 0;
        for(int i = 0; i < 2; i++)
        {
            if (itemBoxes[i].isOveraped == true)
            {
                count++;
            }
        }

        if (count >= 2)
        {
            Debug.Log("°ÔÀÓ ½Â¸®!");
            isGameOver = true;
            winUI.SetActive(true);
        }
    }
}
