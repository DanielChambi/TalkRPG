using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationController : MonoBehaviour
{
    //Dialogue text field
    public TextMeshProUGUI textPanel;

    //Current dialogue node
    [SerializeField]
    Node currNode;

    //Feeling meters for traversing nodes
    public int[] meters { get; private set; }
    public static int metersCount = 3;

    
    void Start()
    {
        meters = new int[metersCount];

        Node n1 = new Node(0, "Node 1");
        Node n2 = new Node(1, "Node 2");
        n1.AddLink(n2, new int[] { 20, 0 ,0});
        n2.AddLink(n1, new int[] { 0, 20, 0});

        currNode = n1;

        Write(currNode.text);     
    }

    //Write given text on dialogue box
    void Write(string text)
    {
        textPanel.SetText(text);
    }

    //Apply meter variation with index and quantity
    public void UpdateMeter(int index, int delta)
    {
        meters[index] += delta;
        if (meters[index] > 100) meters[index] = 100;
        if (meters[index] < 0) meters[index] = 0;
    }

    //Select next conversation node based on conditions
    public void AdvanceConversation()
    {
        Node next = currNode.Next(meters);
        if (next != null)
        {
            currNode = next;
            Write(currNode.text);
        }
    }
}
