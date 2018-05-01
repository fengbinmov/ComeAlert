using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class AICountrysOperation
{

    private ObjectSystem mObjectSystem;
    private MakePolicySystem mMakePolicySystem = new MakePolicySystem();
    private InferSystem mInferSystem = new InferSystem();
    private AllotSystem mAllotSystem = new AllotSystem();
    private MoveSystem mMoveSystem = new MoveSystem();


    public void Init(ObjectSystem objectSystem) {
        mObjectSystem = objectSystem;
    }

    public void Update() {

    }
}
