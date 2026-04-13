using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    InputAction menuAction;
    private bool menuOpen = false;

    GameObject menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuAction = InputSystem.actions.FindAction("Menu");
        menu = transform.GetChild(0).gameObject;
        menuAction.performed += (_) => { ToggleMenu(); } ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2;
        transform.rotation = Camera.main.transform.rotation;
    }

    public void ToggleMenu()
    {
        menuOpen = !menuOpen;
        Time.timeScale = (menuOpen) ? 0f : 1f;
        menu.SetActive(menuOpen);
        if (menuOpen)
        {

        }
        else
        {

        }


    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
