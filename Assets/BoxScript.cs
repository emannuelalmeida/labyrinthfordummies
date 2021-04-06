using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var mat = GetComponent<Renderer>().material;
        mat.SetColor("_Color", Color.green);
        Debug.Log(mat.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
    }
}
