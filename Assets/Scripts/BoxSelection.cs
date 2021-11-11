using System.Collections.Generic;
using UnityEngine;

public class BoxSelection : MonoBehaviour
{
    [SerializeField] Collider[] selections;
    [SerializeField] Box box;
    private Vector3 startPos, dragPos;
    private Camera cam;
    private Ray ray;
    private List<IUnit> unitSelected = new List<IUnit>();


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 200f) && unitSelected.Count > 0)
                foreach (var go in unitSelected)
                {
                    go.MoveUnitToPoint(hit.point);
                }
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            ray = cam.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit, 200f);

            if (Input.GetMouseButtonDown(0))
            {
                // on drag start
                startPos = hit.point;
                box.baseMin = startPos;
            }

            // when dragging
            dragPos = hit.point;
            box.baseMax = dragPos;
            Debug.Log(hit.point);
        }
        else if ((Input.GetMouseButtonUp(0)))
        {
            selections = Physics.OverlapBox(box.Center, box.Extents, Quaternion.identity);
            foreach (Collider collider in selections)
            {
                IUnit go = collider.GetComponent<IUnit>();
                if (go != null)
                {
                    go.SetSelectedFlag(true);
                    unitSelected.Add(go);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(box.Center, box.Size);
    }
}

[System.Serializable]
public class Box
{
    public Vector3 baseMin, baseMax;

    public Vector3 Center
    {
        get
        {
            Vector3 center = baseMin + (baseMax - baseMin) * 0.5f;
            center.y = (baseMax - baseMin).magnitude * 0.5f;
            return center;
        }
    }

    public Vector3 Size
    {
        get
        {
            return new Vector3(Mathf.Abs(baseMax.x - baseMin.x), (baseMax - baseMin).magnitude, Mathf.Abs(baseMax.z - baseMin.z));
        }
    }

    public Vector3 Extents
    {
        get
        {
            return Size * 0.5f;
        }
    }
}
