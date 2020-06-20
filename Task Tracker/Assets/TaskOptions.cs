using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskOptions : MonoBehaviour
{
    [System.Serializable]
    public struct status
    {
        public string name;
        public int color;
    }

    public List<status> states;

    [SerializeField] private GameObject TaskPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        //Call at the start to add in our tags
        UpdateStatuses();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewTask(string name)
    {
        if (name.Length == 0) return;
        GameObject newTask = Instantiate(TaskPrefab);
        newTask.transform.parent = transform;
        newTask.GetComponent<Task>().Setup(name);

        //Update all, just to make sure
        //UpdateStatuses();
    }

    public void UpdateStatuses()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.CompareTag("Task"))
            {
                child.GetComponent<Task>().SetStatusOptions(states);
            }
        }
    }
}
