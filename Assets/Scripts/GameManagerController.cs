using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private UIManagerController uiManager;
    public UIManagerController UiManager
    {
        get
        {
           return uiManager;
        }
        set
        {
            uiManager = value;
        }
    }

}
