using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class InputGetKey : MonoBehaviour
{
    [SerializeField]
    List<KeyCode> rndkeycodes = new List<KeyCode>{ KeyCode.Q, KeyCode.W,KeyCode.E,KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P,
                              KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L,
                              KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M,
                              KeyCode.Alpha0,KeyCode.Alpha1,KeyCode.Alpha2,KeyCode.Alpha3,KeyCode.Alpha4,KeyCode.Alpha5,KeyCode.Alpha6,KeyCode.Alpha7,KeyCode.Alpha8,KeyCode.Alpha9};
    [SerializeField]
    List<KeyCode> rmdkeycodes;

    const int kaburiNum = 8;

    public List<KeyCode> keys;
    public bool[] IskeyDown = new bool[4];
    public bool IsAllKeyDown = true;
    // Start is called before the first frame update
    void Start()
    {
        InitKeySet();
    }

    // Update is called once per frame
    void Update()
    {
        BoolReset();
        IsAllKeyDown = true;
        int i = 0;
        foreach (KeyCode c in keys)
        {
            if (Input.GetKey(c))
            {
                IskeyDown[i] = true;
            }
            else
            {
               // print(c + ":no");
            }
            i++;
        }

        foreach (bool ikd in IskeyDown)
        {
            if (!ikd)
                IsAllKeyDown = false;
        }

        if (IsAllKeyDown)
        {
            KeyChange();
        }

    }

    public void BoolReset()
    {
        for (int i = 0; i < IskeyDown.Length; i++)
        {
            IskeyDown[i] = false;
        }
        IsAllKeyDown = false;
    }
    public void InitKeySet()
    {
        for (int i = 0; i < kaburiNum; i++)
        {
            int rnd = Random.Range(0, rndkeycodes.Count);
            KeyCode key = rndkeycodes[rnd];
            rndkeycodes.RemoveAt(rnd);

            if (i > kaburiNum - 4 - 1)
                keys.Add(key);

            rmdkeycodes.Add(key);
        }

    }
    public void KeyChange()
    {
        keys.RemoveAt(0);
        int rnd = Random.Range(0, rndkeycodes.Count);
        KeyCode key = rndkeycodes[rnd];

        rndkeycodes.RemoveAt(rnd);
        rndkeycodes.Add(rmdkeycodes[0]);

        rmdkeycodes.RemoveAt(0);
        rmdkeycodes.Add(key);

        keys.Add(key);
    }
}
