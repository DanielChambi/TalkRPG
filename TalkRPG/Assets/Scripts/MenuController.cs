using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    //Marks for selected option
    [SerializeField]
    public GameObject[] ticks;
    //Option text object
    [SerializeField]
    public GameObject[] optionText;

    //General controller for conversation scenario
    public ConversationController convController;

    //Options currently on display
    Option[] currMenu;
    int currOption;

    
    void Start()
    {
        //Start up tick
        currOption = 0;
        ticks[currOption].SetActive(true);

        //Placeholder menu
        currMenu = new Option[] { new Option(0, "Option 1"), new Option(1, "Option 2"),
                                  new Option(2, "Option 3"), new Option(3, "Option 4")};
     
        UpdateMenuText();
    }

    
    void Update() {

        //Get vertical input
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

        //Get horizontal input
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

        //Get selection input
        if (Input.GetButtonDown("Submit"))
        {
            SelectOption();
        }
        
    }

    //Shift selected option by ammount
    void MoveOption(int i)
    {
        ticks[currOption].SetActive(false);
        currOption += i;
        ticks[currOption].SetActive(true);
    }

    //Do thing on selected option
    void SelectOption()
    {
        Debug.Log("Selected option: " + currMenu[currOption].name);

        int optId = currMenu[currOption].id;
        switch (optId)
        {
            case 0:
                convController.UpdateMeter(0, 100);
                convController.UpdateMeter(1, 100);
                break;
            case 1:
                convController.UpdateMeter(0, 10);               
                break;
            case 2:                
                convController.UpdateMeter(1, 10);
                break;
            case 3:
                convController.UpdateMeter(0, -100);
                convController.UpdateMeter(1, -100);
                break;
            default:
                break;
        }

        //Next dialoge
        convController.AdvanceConversation();
    }

    //Set corresponding option text
    void UpdateMenuText()
    {
        for(int i = 0; i <= 3; i++)
        {
            TextMeshProUGUI tmp = optionText[i].GetComponent<TextMeshProUGUI>();
            tmp.SetText(currMenu[i].name); 
        }
    }

    
}
