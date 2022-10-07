using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Seeker : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    public bool isRight = false;
    public Vector2 targetPos = new Vector2();
    public Vector2 oldTargetPos;

    public Vector2 pos;
    public Vector2 vel;
    public Vector2 acc;
    public float Max_Speed;
    public float Max_Force;



    void Start()
    {
        
        oldTargetPos = new Vector2(2f, 2f);
        pos = (Vector2)transform.position;
        vel = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2)target.transform.position != targetPos)
        {
            oldTargetPos = targetPos;
            targetPos = (Vector2)target.transform.position;
            isRight = false;
        }

        defineAcc(Seek());

        Move();

        camFix();
    }

    public Vector2 Seek()
    {
        var desiredVelocity = targetPos - (Vector2)transform.position;
        //desiredVelocity = Vector2.ClampMagnitude(desiredVelocity, Max_Speed);
        desiredVelocity = desiredVelocity.normalized * Max_Speed;

        var steering = desiredVelocity -= vel;
        //steering = Vector2.ClampMagnitude(steering, Max_Force);
        steering = steering.normalized * Max_Force;

        return steering;
        
    }

    public void defineAcc(Vector2 vec)
    {
        acc += vec;
    }

    public void Move()
    {
        vel += acc/2;

        vel = Vector2.ClampMagnitude(vel, Max_Speed);

        transform.position += new Vector3(vel.x, vel.y, 0) * Time.deltaTime;

        float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        acc = Vector2.zero;
    }

    public void camFix()
    {
        if (transform.position.x > 9.5)
        {
            transform.position = new Vector3(-8f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5)
        {
            transform.position = new Vector3(8f, transform.position.y, 0);
        }

        if (transform.position.y > 5.5)
        {
            transform.position = new Vector3(transform.position.x, -3f, 0);
        }
        else if (transform.position.y < -5.5)
        {
            transform.position = new Vector3(transform.position.x, 3f, 0);
        }
    }

}
