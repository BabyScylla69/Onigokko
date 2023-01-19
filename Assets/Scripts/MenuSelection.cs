using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;



public class MenuSelection : MonoBehaviour
{
    public GameObject Button;
    public GameObject Icon;
    public List<GameObject> _buttons;
    public List<GameObject> _iconPositions;
    [SerializeField]
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        Icon.transform.position = _iconPositions[0].transform.position;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Button);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if(i == 3)
            {
                i = 0;
            }
            else
            {
                i = i + 1;
            }
            Icon.transform.position = _iconPositions[i].transform.position;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_buttons[i]);

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (i == 0)
            {
                i = 3;
            }
            else
            {
                i = i - 1;
            }

            Icon.transform.position = _iconPositions[i].transform.position;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_buttons[i]);
        }
    }
}
