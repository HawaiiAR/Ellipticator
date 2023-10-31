using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineRotator : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
}
