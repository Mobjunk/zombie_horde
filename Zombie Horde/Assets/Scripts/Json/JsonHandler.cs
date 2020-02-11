using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class JsonHandler<T> : MonoBehaviour
{
    public List<T> entries = new List<T>();

    protected abstract string GetFileName();

    protected abstract string GetPath();

    public virtual void Start()
    {
        Load();
    }

    public void Save()
    {
        var array = new T[entries.Count];
        
        for (var index = 0; index < array.Length; index++)
            array[index] = entries[index];
        
        var toJson = JsonHelper.ToJson(array, true);
        Debug.Log(toJson);
        
        var sr = File.CreateText($"{GetPath()}{GetFileName()}");
        sr.WriteLine (toJson);
        sr.Close();
    }

    public void Load()
    {
        var jsonString = "";
        var reader = new StreamReader($"{GetPath()}{GetFileName()}");
        jsonString = reader.ReadToEnd();
        reader.Close();
        
        var array = JsonHelper.FromJson<T>(jsonString);
        foreach (var entry in array)
            entries.Add(entry);
    }
}