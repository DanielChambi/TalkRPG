using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option
{
    public int id { get; }
    public string name { get; }

    public Option(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public override string ToString()
    {
        return "Option_ID: " + id + " Option_Name: " + name;
    }
}
