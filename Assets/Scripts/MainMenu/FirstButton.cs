using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FirstButton : MonoBehaviour
{
    [SerializeField] Button initButton;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (initButton != null)
        {
            ActivateButton();
        }
    }

    void ActivateButton()
    {
        EventSystem.current.SetSelectedGameObject(initButton.gameObject, null);
        initButton.Select();
        Debug.Log("boton" + initButton);
    }
}
