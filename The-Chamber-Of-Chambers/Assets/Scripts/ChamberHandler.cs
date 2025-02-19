using System;
using UnityEngine;

public class ChamberHandler : MonoBehaviour
{
    ChamberBrain _selectedChamber;

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) {
            if(hit.collider.TryGetComponent(out ChamberBrain chamberBrain)) {
                if(Input.GetMouseButtonDown(0)) {
                    _selectedChamber = chamberBrain;
                }
            }
        }

        if(Physics.Raycast(ray, out RaycastHit hit2, Mathf.Infinity)) {
            if(hit2.collider.TryGetComponent(out Resource resource)) {
                if(Input.GetMouseButtonDown(0)) {
                    if(_selectedChamber != null) {
                        _selectedChamber.SetTarget(resource);
                    }
                }
            }
        }
    }
}
