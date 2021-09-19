using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointIncrease : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
        this.transform.position = new Vector3(this.gameObject.transform.position.x, this.transform.position.y + Time.fixedDeltaTime * 5, this.transform.position.z);
    }
}
