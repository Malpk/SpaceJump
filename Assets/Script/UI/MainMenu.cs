using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MainMenu))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartGame()
    {
        _animator.SetBool("start", true);
    }

    public void ShowMainMenu()
    {
        _animator.SetBool("start", false);
    }
}
