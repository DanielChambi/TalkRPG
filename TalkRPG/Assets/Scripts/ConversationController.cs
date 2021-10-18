using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationController : MonoBehaviour
{
    public TextMeshProUGUI textPanel;

    // Start is called before the first frame update
    void Start()
    {
        Write("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Write(string text)
    {
        textPanel.SetText(text);
    }
}
