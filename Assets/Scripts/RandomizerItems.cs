using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RandomizerItems : MonoBehaviour
{
    public List<GameObject> _positionsA, _positionsB, _positionsC, _positionsD;
    public GameObject noteA, noteB, noteC, noteD;
    public TextMeshProUGUI _textA, _textB, _textC, _textD;

    [SerializeField]
    private string inputField;
    [SerializeField]
    private string codeLock;

    [SerializeField]
    private List<int> objectsSeed, objectsNum;

    [SerializeField]
    private int seed;
    [SerializeField]
    private string actualSeed, actualPos, actualNum;
    // Start is called before the first frame update
    void Awake()
    {
        seed = (int)System.DateTime.Now.Ticks;
        UnityEngine.Random.InitState(seed);
        actualSeed = seed.ToString();

        for(int i = 0; i < 4; i++)
        {
            objectsSeed[i] = UnityEngine.Random.Range(0, 9);
            objectsNum[i] = UnityEngine.Random.Range(0, 10);
        }

        _textA.text = objectsNum[0].ToString();
        _textB.text = objectsNum[1].ToString();
        _textC.text = objectsNum[2].ToString();
        _textD.text = objectsNum[3].ToString();
        codeLock = _textA.text + _textB.text + _textC.text + _textD.text;
        Debug.Log(codeLock);
        //-------------------------------------------------------------------------
        noteA.transform.position = _positionsA[objectsSeed[0]].transform.position;
        noteA.transform.rotation = _positionsA[objectsSeed[0]].transform.rotation;
        //-------------------------------------------------------------------------
        noteB.transform.position = _positionsB[objectsSeed[1]].transform.position;
        noteB.transform.rotation = _positionsB[objectsSeed[1]].transform.rotation;
        //-------------------------------------------------------------------------
        noteC.transform.position = _positionsC[objectsSeed[2]].transform.position;
        noteC.transform.rotation = _positionsC[objectsSeed[2]].transform.rotation;
        //-------------------------------------------------------------------------
        noteD.transform.position = _positionsD[objectsSeed[3]].transform.position;
        noteD.transform.rotation = _positionsD[objectsSeed[3]].transform.rotation;
        //-------------------------------------------------------------------------
        Debug.Log(objectsNum[0]);
        Debug.Log(objectsNum[1]);
        Debug.Log(objectsNum[2]);
        Debug.Log(objectsNum[3]);
    }

    public void ReadInputField(TextMeshProUGUI check)
    {
        inputField = check.text;


        if (inputField.Length - 1 != codeLock.Length)
            return;

        for (int i = 0; i < codeLock.Length; i++)
        {
            if (codeLock[i] != inputField[i])
                return;
        }

        Debug.Log("Es correcto");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
