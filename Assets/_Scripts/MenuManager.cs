using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    InputAction _menuAction;

    bool isMenuOpen = false;

    void Awake()
    {
        _menuAction = InputSystem.actions.FindAction("Menu");

        _menuAction.performed += MenuAction_performed;
    }

    private void MenuAction_performed(InputAction.CallbackContext context)
    {
        _menuAction.performed -= MenuAction_performed;

        if (!isMenuOpen)
        {
            Time.timeScale = 0f;
            isMenuOpen = true;
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }
        else
        {
            isMenuOpen = false;
            SceneManager.UnloadSceneAsync("Menu");
            Time.timeScale = 1f;
        }

        _menuAction.performed += MenuAction_performed;
    }

    private void OnDestroy()
    {
        _menuAction.performed -= MenuAction_performed;
    }
}
