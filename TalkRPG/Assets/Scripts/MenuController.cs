using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject[] ticks;
    [SerializeField]
    public GameObject[] optionText;

    public ConversationController convController;

    Option[] currMenu;

    int currOption;

    // Start is called before the first frame update
    void Start()
    {
        currOption = 0;
        ticks[currOption].SetActive(true);

        currMenu = new Option[] { new Option(0, "Option 1"), new Option(1, "Option 2"),
                                  new Option(2, "Option 3"), new Option(3, "Option 4")};

        UpdateMenu();


    }

    // Update is called once per frame
    void Update() {
        float xAxis, yAxis;

        if (Input.GetButtonDown("Vertical"))
        {
            yAxis = Input.GetAxis("Vertical");

            if (yAxis < 0 && currOption % 2 == 0)
            {
                MoveOption(1);
            }
            if (yAxis > 0 && currOption % 2 == 1)
            {
                MoveOption(-1);
            }
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            xAxis = Input.GetAxis("Horizontal");
            if (xAxis < 0 && currOption > 1)
            {
                MoveOption(-2);
            }
            if (xAxis > 0 && currOption < 2)
            {
                MoveOption(2);
            }
        }


        if (Input.GetButtonDown("Submit"))
        {
            SelectOption();
        }
        
    }

    void MoveOption(int i)
    {
        ticks[currOption].SetActive(false);
        currOption += i;
        ticks[currOption].SetActive(true);
    }

    void SelectOption()
    {
        Debug.Log("Selected option: " + currMenu[currOption].name);

        int optId = currMenu[currOption].id;
        switch (optId)
        {
            case 0:
                convController.NextNode();
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }

    void UpdateMenu() {
        for(int i = 0; i <= 3; i++)
        {
            TextMeshProUGUI tmp = optionText[i].GetComponent<TextMeshProUGUI>();
            tmp.SetText(currMenu[i].name); 
        }
    }

}
