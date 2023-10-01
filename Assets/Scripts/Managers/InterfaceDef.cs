using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITap
{
    // Will determine what to do when an object is tapped. Must be incorporated in each object that uses this interface
    void onTapAction();
}
