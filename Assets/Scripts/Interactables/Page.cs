using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : Interactable
{
    [SerializeField] private GameObject item;
    private bool lift;

    protected override void Interact()
    {
        lift = !lift;
        item.GetComponent<Animator>().SetBool("isLifted", lift);
    }
}
