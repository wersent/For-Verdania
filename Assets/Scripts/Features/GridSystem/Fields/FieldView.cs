using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using Zenject;

public class FieldView : MonoBehaviour
{
    FieldViewModel _fieldVM;

    [Inject]
    public void Init(FieldViewModel fieldVM)
    {
        _fieldVM = fieldVM;
    }

    public class Factory : PlaceholderFactory<FieldViewModel, FieldView> { }
}