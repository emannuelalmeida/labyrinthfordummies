using UnityEngine;

public class MapEnding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("You have reached the end of the map. Congratulations!!");
        }
        
        Debug.Log(collision.collider.name);
    }

}
