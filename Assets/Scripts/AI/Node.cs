using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Node
{
    // Constructor
    public Node() { }

    public delegate NodeStates NodeReturn();

    // The state of the node
    protected NodeStates state;

    // Getter function for the state of this node
    public NodeStates NodeState
    {
        get { return state; }
    }

    // Evaluate function is where the magic happens
    // This determines the action this node takes
    public abstract NodeStates Evaluate();
}
