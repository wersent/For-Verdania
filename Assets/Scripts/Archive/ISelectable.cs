using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public interface ISelectable
{
    void OnClick(GameObject gameObject);
}
