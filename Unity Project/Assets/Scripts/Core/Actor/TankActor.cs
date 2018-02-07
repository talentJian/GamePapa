using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class TankActor : BaseActor {
    [System.Serializable]
    public class TankData
    {
        public float moveSpeed;
        public float turnSpeed;
    }
    public TankData tankData;

    Rigidbody rigidbody;
    BoxCollider boxCollider;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        boxCollider = this.GetComponent<BoxCollider>();

        InputHandler.Instantce.OnKeyMove+=Move;
    }
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        InputHandler.Instantce.OnKeyMove-=Move;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {

    }

    public void Move(Vector2 dir)
    {
        if(dir == Vector2.zero)
        return;
        var v3Dir =  new Vector3(dir.x,0,dir.y);

        var angle = Vector3.Angle(this.transform.forward,v3Dir);
         
        var LookRotation= Quaternion.LookRotation(v3Dir,this.transform.up);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation,LookRotation,Time.deltaTime * tankData.turnSpeed);
         if(angle >= 100)
         {
          return;   
         }
        //if(angle <= 45)
        //{
            this.transform.position += this.transform.forward* tankData.moveSpeed * Time.deltaTime;
        //}
       
    }
}
