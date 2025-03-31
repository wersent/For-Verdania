using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHighlightable
{
    void Highlight(Color color);
    void ResetHighlight();
}
