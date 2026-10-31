using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInParticule : Interactable
{
    [SerializeField]
    private GameObject particule;

    protected override void Interact()
    {
        Destroy(gameObject);
        Instantiate(particule, particule.transform.position, particule.transform.rotation);
    }
}
