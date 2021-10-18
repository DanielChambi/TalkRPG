using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationController : MonoBehaviour
{
    public TextMeshProUGUI textPanel;

    [SerializeField]
    Node currNode;

    // Start is called before the first frame update
    void Start()
    {
        Node n1 = new Node(0, "Node 1");
        Node n2 = new Node(1, "Node 2");
        n1.AddFollowing(n2);

        currNode = n1;

        Write(currNode.text);
    }

    void Write(string text)
    {
        textPanel.SetText(text);
    }

    public void NextNode()
    {
        Node next = currNode.Next();
        if (next != null)
        {
            currNode = next;
            Write(currNode.text);
        }
    }
}
