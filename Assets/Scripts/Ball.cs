using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;
    public static Ball GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

}
