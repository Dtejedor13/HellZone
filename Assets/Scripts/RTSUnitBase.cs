using UnityEngine;

public class RTSUnitBase : MonoBehaviour, IUnit
{
    [SerializeField] Material isSelectedMaterial;
    [SerializeField] Material isNotSelectedMaterial;

    public void SetSelectedFlag(bool isSelected)
    {
        GetComponent<MeshRenderer>().material = isSelected ? isSelectedMaterial : isNotSelectedMaterial;
    }

    public void MoveUnitToPoint(Vector3 point)
    {
        GetComponent<UnitNavMesh>().SetMovePosition(point);
    }

    public void ClearTarget()
    {
        //GetComponent<UnitNavMesh>().MovePosition = null;
    }
}
