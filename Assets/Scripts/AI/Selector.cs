using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    // List of child Nodes for this Selector
    protected List<Node> childNodes = new List<Node>();

    public Selector(List<Node> nodes)
    {
        childNodes = nodes;
    }

    // Evaluate needs to return SUCCESS or RUNNING if any of it's children return SUCCESS or RUNNING
    // Selectors only return FAILURE if all of it's children return FAILURE
    public override NodeStates Evaluate()
    {
        foreach (Node n in childNodes)
        {
            switch (n.Evaluate())
            {
                case NodeStates.FAILURE:
                    continue;
                case NodeStates.SUCCESS:
                    state = NodeStates.SUCCESS;
                    return state;
                case NodeStates.RUNNING:
                    state = NodeStates.RUNNING;
                    return state;
                default:
                    continue;
            }
        }
        state = NodeStates.FAILURE;
        return state;
    }
}
