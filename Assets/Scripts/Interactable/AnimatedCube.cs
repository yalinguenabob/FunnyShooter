using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCube : Interactable
{
    private string startPrompt;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startPrompt = promptMessage;
    }

    // Update is called once per frame
    void Update()
    {
       promptMessage = startPrompt;
    }

    protected override void Interact()
    {
        animator.enabled = true;
        promptMessage = "animating...";
    }
}
