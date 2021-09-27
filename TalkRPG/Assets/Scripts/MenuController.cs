using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject[] ticks;
    [SerializeField]
    public GameObject[] optionText;

    int currOption;

    // Start is called before the first frame update
    void Start()
    {
        currOption = 0;
        ticks[currOption].SetActive(true);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown("down") && currOption % 2 == 0)
        {
            MoveOption(1);
        }
        if (Input.GetKeyDown("up") && currOption % 2 == 1)
        {
            MoveOption(-1);
        }
        if (Input.GetKeyDown("left") && currOption > 1)
        {
            MoveOption(-2);
        }
        if (Input.GetKeyDown("right") && currOption < 2)
        {
            MoveOption(2);
        }
    }

    void MoveOption(int i)
    {
        ticks[currOption].SetActive(false);
        currOption += i;
        ticks[currOption].SetActive(true);
    }
}
