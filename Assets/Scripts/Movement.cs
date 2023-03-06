using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    float mergsize;
    public GameObject[] Players;
    public GameObject BigPlayers;
    public GameObject LosePanel;
    public GameObject WinPanel;
    bool IsGameStart = false;
    bool IsFinish = false;
    Vector3 Move = Vector3.forward;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!IsGameStart&&!IsFinish)
        {
            IsGameStart = true;
            speed = 8f;
        }

        if (IsGameStart)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Animator>().SetBool("Ismove", true);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Animator>().SetBool("Ismove", false);
            }
        }


        transform.Translate(Move * speed * Time.deltaTime);
        float Distance = Vector3.Distance(Players[0].transform.position, Players[1].transform.position);

        if (Distance < .1f)
        {
            Players[0].SetActive(false);
            Players[1].SetActive(false);
            BigPlayers.SetActive(true);

        }
        else
        {
            Players[0].SetActive(true);
            Players[1].SetActive(true);
            BigPlayers.SetActive(false);
        }
    }

    public void BigPlayerScale()
    {
        mergsize += 0.01f;
        BigPlayers.GetComponent<Transform>().localScale += Vector3.one * mergsize;
    }
    public void DoorCollision()
    {
        IsFinish = true;
        IsGameStart = false;
        LosePanel.SetActive(true);
        speed = 0f;
        foreach (Transform child in transform)
        {
            child.GetComponent<Animator>().SetBool("Ismove", false);
        }
        GameObject.FindWithTag("PlayerInput").GetComponent<InputController>().enabled = false;
    }
    public void FinishLineCollision()
    {
        IsFinish = true;
        IsGameStart = false;
        WinPanel.SetActive(true);
        speed = 0f;
        foreach (Transform child in transform)
        {
            child.GetComponent<Animator>().SetBool("Ismove", false);
        }
        GameObject.FindWithTag("PlayerInput").GetComponent<InputController>().enabled = false;

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        speed = 8f;
        foreach (Transform child in transform)
        {
            child.GetComponent<Animator>().SetBool("Ismove", false);
        }
        GameObject.FindWithTag("PlayerInput").GetComponent<InputController>().enabled = true;
    }

}
