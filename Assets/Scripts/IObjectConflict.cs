using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectConflict {
    int Conflict(CShipHealth health);
    void DestroyObject();
}
