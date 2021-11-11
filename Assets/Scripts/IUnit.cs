using UnityEngine;

internal interface IUnit
{
    void SetSelectedFlag(bool isSelected);

    void MoveUnitToPoint(Vector3 point);
}