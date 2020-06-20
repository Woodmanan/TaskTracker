using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private static ColorManager Instance;

    public static ColorManager instance
    {
        get
        {
            if (!Instance)
            {
                GameObject oldManager = GameObject.FindGameObjectWithTag("ColorManager");
                if (oldManager)
                {
                    Instance = oldManager.GetComponent<ColorManager>();
                }
                else
                {
                    print("Manager not found, making a new one!");
                    GameObject newManager = new GameObject();
                    Instance = newManager.AddComponent<ColorManager>();
                }
            }
            return Instance;
        }


        set => Instance = value;
    }

    public List<Color> colors;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
        {
            instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
