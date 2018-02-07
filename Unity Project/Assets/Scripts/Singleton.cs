using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T :new () {
    private static T _instance;

    public static T Instantce
    {
        get
        {
            if (_instance == null)
                _instance = new T();
            return _instance;
        }
    }
}

public class SingletonMono<T> :MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instantce
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
            }
            return _instance ;
        }
    }
}