﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController
{

    public static string defaultPlayerName = "A Player"; 
    public static Color defaultPrimaryColor = new Color();
    public static Color defaultAccentColor = new Color(.77f,0,0); 

    // =======================================================
    public Color primaryColor
    {
        get
        {
            string prefPrimaryColor = PlayerPrefs.GetString("primaryColor", ColorToString(defaultPrimaryColor));
            return StringToColor(prefPrimaryColor);
        }
        set
        {
            PlayerPrefs.SetString("primaryColor", ColorToString(value));
        }
    }
    // =======================================================
    public Color accentColor
    {
        get
        {
            string prefAccentColor = PlayerPrefs.GetString("accentColor", ColorToString(defaultAccentColor));
            return StringToColor(prefAccentColor);
        }
        set
        {
            PlayerPrefs.SetString("accentColor", ColorToString(value));
        }
    }
    // =======================================================
    public string playerName
    {
        get { return PlayerPrefs.GetString("playerName", defaultPlayerName); }
        set
        {
            PlayerPrefs.SetString("playerName", value);
        }
    }

    string ColorToString(Color color)
    {
        return $"{color.r},{color.g},{color.b},{color.a}";
    }


    Color StringToColor(string stringColor)
    {
        string[] rgba = stringColor.Split(',');
        var colors = new List<string>(rgba).ConvertAll<float>(ele => float.Parse(ele));
        if (rgba.Length == 4) return new Color(colors[0], colors[1], colors[2], colors[3]);
        return new Color();
    }


}