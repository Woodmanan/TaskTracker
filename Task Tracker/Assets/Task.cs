using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private TMP_Dropdown stateDropdown;

    [SerializeField] private InputField title;

    public Task parent;
    
    // Start is called before the first frame update
    void Start()
    {
        stateDropdown.onValueChanged.AddListener(SetStatusColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(string name)
    {
        title.text = name;
    }

    public void SetStatusOptions(List<TaskOptions.status> options)
    {
        int value = stateDropdown.value;
        stateDropdown.ClearOptions();
        List<String> opts = new List<string>();
        foreach (TaskOptions.status stat in options)
        {
            opts.Add(stat.name);
        }
        stateDropdown.AddOptions(opts);
        
        SetStatusColor(value);
    }

    public void SetStatusColor(int status)
    {
        Color c = ColorManager.instance.colors[status];
        GetComponent<Image>().color = c;
    }

    public void PropogateRebuild()
    {
        if (parent)
        {
            parent.PropogateRebuild();
        }
        else
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform) transform);
        }
    }
}
