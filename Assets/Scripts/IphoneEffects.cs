using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IphoneEffects : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> _panels;
    private float time;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        if(time <= 0)
        {
            _panels[i].SetActive(false);

            if(i >= 7)
            {
                i = -1;
            }

            i++;

            _panels[i].SetActive(true);
            time = 0.05f;
        }
    }
}
