using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int id { get; }
    public string text { get; }
    List<Node> following;

    public Node(): this(-1, "")
    {
    }

    public Node(int id, string text)
    {
        this.id = id;
        this.text = text;
        following = new List<Node>();
    }

    public Node Next()
    {
        Node result = null;
        if (following.Count > 0)
        {
            result = following[0];
        }
        return result;
    }

    public void AddFollowing(Node node)
    {
        following.Add(node);
    }

    public override string ToString()
    {
        return "Node id: " + id + " Text: " + text;
    }

}
