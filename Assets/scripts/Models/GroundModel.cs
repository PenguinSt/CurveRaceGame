using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundModel : MonoBehaviour
{
    // Start is called before the first frame update
    public string id;
    public GameObject ground;
    public Color groundColor= Color.blue;

    private void Start()
    {
        id = gameObject.name;
    }
}
