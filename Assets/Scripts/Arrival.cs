using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrival : Seeker
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)target.transform.position != targetPos)
        {
            oldTargetPos = targetPos;
            targetPos = (Vector2)target.transform.position;
            isRight = false;
        }

        defineAcc(Arrive());

        Move();

        camFix();
    }

    public Vector2 Arrive()
    {
        var desiredVelocity = targetPos - (Vector2)transform.position;
        float dist = desiredVelocity.magnitude;

        if(dist < 6)
        {
            desiredVelocity = desiredVelocity.normalized * dist;
        }
        else
        {
            desiredVelocity = desiredVelocity.normalized * Max_Speed;
        }
        //desiredVelocity = Vector2.ClampMagnitude(desiredVelocity, Max_Speed);
        



        var steering = desiredVelocity -= vel;
        //steering = Vector2.ClampMagnitude(steering, Max_Force);
        steering = steering.normalized * Max_Force;

        return steering;
    }
}
