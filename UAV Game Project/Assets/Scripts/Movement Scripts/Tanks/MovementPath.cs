using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes{ // вид пути
    linear,
    loop
    }
    public PathTypes PathType;
    public int movementDirection = 1;
    public int moveinTo = 0;
    public Transform[] PathElements;

    public void OnDrawGizmos() // отображает линии 
     {
       if (PathElements == null || PathElements.Length < 2 ){
           return;
       } 
       for (var i = 1; i < PathElements.Length; i++)
       {
           Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
       }
       if (PathType == PathTypes.loop)
       {
       Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);

       }
       
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathElements  == null || PathElements.Length < 1)
        {
            yield break;
        }
        while (true)
        {
            yield return PathElements[moveinTo];

           if(PathElements.Length == 1 )
           {
               continue;
           }
           if (PathType == PathTypes.linear)
           {
               if (moveinTo <= 0)
               {
                   movementDirection = -1;
               }
               else if (moveinTo >= PathElements.Length - 1)
               {
                   movementDirection = -1;
               }
           }

        moveinTo = moveinTo + movementDirection;

        if (PathType == PathTypes.loop)
        {
            if(moveinTo >= PathElements.Length)
            {
             moveinTo = 0; 
            }
            if (moveinTo < 0 )
            {
                moveinTo = PathElements.Length -1;
            }
            
        }
        }
    }
}
