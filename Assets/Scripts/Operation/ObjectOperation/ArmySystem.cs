using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Reflection;


public class ArmySystem
{
    private AllotSystem mAllotSystem;
    private Stack<Army> mArmy;

    void PushArmy() { }
    void PopArmy() { }

    public void test() {
        MethodInfo methodInfo = mAllotSystem.GetType().GetMethod("sdfds");
        methodInfo.Invoke(mAllotSystem, null);
    }
}
public class Army {

}
