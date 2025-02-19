using System;
using UnityEngine;

public class ChamberHandler : MonoBehaviour
{
    ChamberBrain _selectedChamber;

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) 
        {
            if(hit.collider.TryGetComponent(out ChamberBrain chamberBrain)) {
                if(Input.GetMouseButtonDown(0)) {
                    _selectedChamber = chamberBrain;
                }
            }

            if(hit.collider.TryGetComponent(out Resource resource)) {
                if(Input.GetMouseButtonDown(0)) {
                    if(_selectedChamber != null) {
                        _selectedChamber.SetTarget(resource);
                    }
                }
            }

            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor")) {
                if(Input.GetMouseButtonDown(0)) {
                    if(_selectedChamber != null) {
                        _selectedChamber.GotoPosition(hit.point);
                    }
                }
            }
        }
        
    }
}
