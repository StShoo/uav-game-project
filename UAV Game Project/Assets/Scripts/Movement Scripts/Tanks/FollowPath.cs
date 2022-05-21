using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        Moveing,
        Lerping
    }

    public MovementType Type = MovementType.Moveing; 
    public MovementPath MyPath;
    public float speed = 1; 
    public float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;

    //public Transform target;

    void Start()
    {
        if (MyPath == null)
        {
            Debug.Log("Примени путь ");
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        

        if(pointInPath.Current == null)
        {
            Debug.Log("нужни точки ");
            return;

        }
        transform.position = pointInPath.Current.position;
    }

    
    void FixedUpdate()
    {
        if(pointInPath == null||
        pointInPath.Current == null)
        {
            return;
        }
        if(Type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position,pointInPath.Current.position,Time.deltaTime*speed);
            //var position = target.position.x;
            //Debug.Log(position);
        }
        else if(Type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position,pointInPath.Current.position,Time.deltaTime*speed);
            //Debug.Log();
        }


        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if(distanceSqure < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }
    }
}
