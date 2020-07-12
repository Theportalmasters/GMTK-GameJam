﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Animator animator;
    public bool open = false;
    // Start is called before the first frame update
    void Awake()
    {
        Degradation.FinalDegradationEvent += Open;
    }

    private void Open()
    {
        animator.SetBool("Open", true);
        Degradation.FinalDegradationEvent -= Open;
        open = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && open)
        {
            SceneManager.UnloadSceneAsync(FindObjectOfType<Map>().index + 1);
            SceneManager.LoadScene(FindObjectOfType<Map>().index + 2, LoadSceneMode.Additive);
            other.transform.position = FindObjectOfType<Map>().startPos.position;
        }
    }
}
