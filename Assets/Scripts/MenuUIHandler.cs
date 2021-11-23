using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [FormerlySerializedAs("ColorPicker")] public ColorPicker colorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.Instance.TeamColor = color;
    }
    
    private void Start()
    {
        colorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        colorPicker.onColorChanged += NewColorSelected;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveButtonClicked()
    {
        MainManager.Instance.SaveColor();
    }

    public void LoadButtonClicked()
    {
        MainManager.Instance.LoadColor();
        colorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
    
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
}
