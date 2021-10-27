using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    //Unique identifiable id
    public int id { get; }
    //Dialogue text for this node
    public string text { get; }

    //Connections and conditions to other nodes
    List<Link> links;

    public Node(int id, string text)
    {
        this.id = id;
        this.text = text;
        links = new List<Link>();
    }

    //Obtain one node from available from current specified conditions
    public Node Next(int[] conditions)
    {
        Node result = null;
        if (links.Count > 0)
        {
            foreach(Link condition in links)
            {
                if (condition.ConditionMet(conditions))
                {
                    result = condition.next;                //returns last available in list 
                }
            }
        }
        return result;
    }

    public void AddLink(Node node)
    {
        links.Add(new Link(node));
    }

    public void AddLink(Node node, int[] conditions)
    {
        links.Add(new Link(node, conditions));
    }

    public override string ToString()
    {
        return "Node id: " + id + " Text: " + text;
    }

}

struct Link
{
    //Objective node
    public Node next;
    //Conditions on meters to unlock route
    int[] metersCondition;

    //New link with conditions set to 0
    public Link(Node node): this(node, new int[ConversationController.metersCount])
    {

    }

    //New link with specific conditions
    public Link(Node node, int[] conditions)
    {
        next = node;
        metersCondition = new int[ConversationController.metersCount];
        for (int i = 0; i < metersCondition.Length; i++)
        {
            metersCondition[i] = conditions[i];
        }

         
    }

    //Check if array of meters meets conditions
    public bool ConditionMet(int[] meters)
    {
        bool result = true;

        int i = 0;

        //Will check conditions for the length of shortest array
        //Arguments array longer than conditions will be used normally
        while(i < metersCondition.Length && i < meters.Length && result == true)
        {
            result = meters[i] >= metersCondition[i];
            i++;
        }

        //If argument array was shorter than conditions consider conditions not met
        if (i < metersCondition.Length) result = false;

        return result;
    }
}
