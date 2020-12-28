using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TerminalButton : MonoBehaviour, IInteractable
{
    [SerializeField]
    UnityEvent Button1;

    public GameObject Prefabs;

    public enum ButtonsFuncs { 
        BUTTON_OPEN, 
        BUTTON_CLOSE,
        BUTTON_CREATE,
        BUTTON_DESTROY

    }

    public ButtonsFuncs ButtonLogic;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate(PlayerInteractable player)
    {
                Button1?.Invoke();
       //switch(ButtonLogic)
       // {
       //     case ButtonsFuncs.BUTTON_OPEN:

       //         Open();

       //         break;

       //     case ButtonsFuncs.BUTTON_CLOSE:

       //         Close();

       //         break;

       //     case ButtonsFuncs.BUTTON_CREATE:

       //         Create();

       //         break;

       //     case ButtonsFuncs.BUTTON_DESTROY:

       //         ButtonDestroy();

       //         break;
       // }

    }
    
    void Open()
    {
        Debug.Log("Open");
    }

    void Close()
    {
        Debug.Log("Close");
    }

    void Create()
    {
        Debug.Log("Create");
    }

    void ButtonDestroy()
    {

    }



}
