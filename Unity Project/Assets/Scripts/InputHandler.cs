using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputHandler : Singleton<InputHandler> {

    public Action<Vector2> OnKeyMove;
    public Action OnKeyMoveUp;
    Vector2 dir =new Vector2();

    private bool lastKeyDown;
	public void DoUpdate()
    {
        bool isKeyOnAsix = false ;
        foreach(var key in asixKeyCode)
        {
            if(Input.GetKey(key))
            { 
                isKeyOnAsix = true;
                lastKeyDown = true;
                break;
            }
        }

        if (isKeyOnAsix)
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical"); 

            dir.x = h;
            dir.y = v;
            //Debug.Log("OnkeyMove " + dir.normalized);
            if (OnKeyMove != null)
            {
                
                OnKeyMove(dir.normalized);
            }
        }
        else
        {
            dir.x = 0;
            dir.y = 0;
            if(lastKeyDown)
            {
                //Debug.Log("OnkeyMove Up " + dir.normalized);
                if (OnKeyMoveUp!= null)
                {
                    OnKeyMoveUp();
                }
            }
            lastKeyDown = false;
        }
    }

    List<KeyCode> asixKeyCode = new List<KeyCode>()
    {
        KeyCode.W,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.UpArrow,
        KeyCode.LeftArrow,
        KeyCode.DownArrow,
        KeyCode.RightArrow
    };
}




















