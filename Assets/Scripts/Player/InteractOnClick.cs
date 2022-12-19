using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOnClick : MonoBehaviour
{
    [SerializeField] LayerMask InteractableLayerMask;
    public static GameManager.Collect a;
    GameObject lastobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) OnAction();
            OnClick();

    }
    private void OnClick()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Debug.DrawLine(transform.position, transform.forward * 5f);
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 5f, InteractableLayerMask))
        {
            if (hitInfo.collider.gameObject != lastobject)
            {
                lastobject = hitInfo.collider.gameObject;
                if (lastobject != null)
                {
                    lastobject.GetComponentInParent<IInteractable>().InteractInfo();
                    a(lastobject.name, true);
                }
            }
        }
        else { lastobject = null; a("", false); }
    }

    private void OnAction()
    {
        lastobject?.GetComponentInParent<IInteractable>().Interact();
    }





}
