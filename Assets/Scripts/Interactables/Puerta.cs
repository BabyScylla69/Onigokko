using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : Interactable
{
    [SerializeField] private GameObject parent;
    private bool open;

    protected override void Interact()
    {
        if(canInteract)
        {
            open = !open;
            parent.GetComponent<Animator>().SetBool("isOpen", open);
        }
    }
}
