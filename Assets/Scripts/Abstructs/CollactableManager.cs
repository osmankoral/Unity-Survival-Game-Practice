using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollactableManager : MonoBehaviour, IInteractable
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
        //Interect Infos
    }

    protected void DestroyGameObject(float _timer = 0)
    {
        Destroy(gameObject, _timer);
    }

}
