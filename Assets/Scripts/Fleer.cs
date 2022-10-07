using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Seeker
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

        defineAcc(Seek() * -1);

        Move();

        camFix();
    }


}
