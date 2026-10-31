using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    // Message displayed to player when looking to interactable
    public string promptMessage;

    // this function will be called from our player
    public void BaseInteract()
    {
        if(useEvents)
        {
            GetComponent<InteractionEvent>().OnInteract.Invoke();                                                                                                                        
        }
         
        Interact();
    }

    protected virtual void Interact()
    {
        // this is a template function to e overriden by our Subclass
    }
}
