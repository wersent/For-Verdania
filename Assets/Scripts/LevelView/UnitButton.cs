using UnityEngine;
using UnityEngine.UI;

namespace LevelView
{
    public class UnitButton : MonoBehaviour
    {
        public void ActivateDropDown(GameObject dropdown)
        {
            dropdown.SetActive(!dropdown.active);
        }
    }
}