using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractanleManager : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        InterectFuntcion();

    }

    public void InteractInfo()
    {
        InterectInfoFuntcion();
    }

    virtual protected void InterectFuntcion()
    {
        //Interect after start fonction
    }
    virtual protected void InterectInfoFuntcion()
    {
        //Interect after start fonction
    }

}
