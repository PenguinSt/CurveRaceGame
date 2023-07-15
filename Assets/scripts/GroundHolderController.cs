using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHolderController : MonoBehaviour
{

    public List<GroundModel> grounds;
    public Camera camera;

    public static string currentGroundNameStr="";

    private int currentGroundIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            Debug.Log(grounds[i].name + "  id= " + grounds[i].id);
            if (currentGroundNameStr.Equals(grounds[i].name))
            {
  
                currentGroundIndex = i;
                break;
            }
        }
        for (int i = 0; i < grounds.Count; i++)
        {
            grounds[i].ground.gameObject.SetActive(false);
            camera.backgroundColor = grounds[currentGroundIndex].groundColor;
            grounds[currentGroundIndex].ground.gameObject.SetActive(true);
        }
    }

}
