using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPos : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 pos = new Vector2();
    public bool col = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(col)
        {
            transform.position = pos;
            col = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        pos = new Vector2(Random.Range(-9, 9), Random.Range(-4, 4));
        col = true;
    }
}
