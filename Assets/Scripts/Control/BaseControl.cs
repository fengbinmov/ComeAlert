using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl {

    protected GameControl gameControl;
    public BaseControl(GameControl gameControl) {
        this.gameControl = gameControl;
    }
    public virtual void OnInit() { }
    public virtual void OnDestriy() { }
    public virtual void Updata() { }

}
