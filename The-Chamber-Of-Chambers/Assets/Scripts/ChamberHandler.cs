using System;
using UnityEngine;
using System.Collections.Generic;

public class ChamberHandler : MonoBehaviour
{
    Queue<ChamberBrain> _selectedChambers = new Queue<ChamberBrain>();
    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) 
        {
            if(hit.collider.TryGetComponent(out ChamberBrain chamberBrain)) {
                if(Input.GetMouseButtonDown(0) && (Input.GetKey(KeyCode.LeftShift) || _selectedChambers.Count < 1)) {
                    _selectedChambers.Enqueue(chamberBrain);
                }
            }else if(hit.collider.TryGetComponent(out HealthHandler healthHandler)) {
                if(Input.GetMouseButtonDown(0)) {
<<<<<<< HEAD
                    if(_selectedChamber != null) {
                        _selectedChamber.SetTarget(healthHandler);
                    }
                }
            }else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor")) {
                if(Input.GetMouseButtonDown(0)) {
                    if(_selectedChamber != null) {
                        _selectedChamber.GotoPosition(hit.point);
=======
                    
                    int a_nChambers = _selectedChambers.Count; 
                    ChamberBrain a_chamber;

                    for(int i = 0; i < a_nChambers; ++i){
                        a_chamber = _selectedChambers.Dequeue();
                        if(a_chamber != null){
                            a_chamber.SetTarget(resource);
                        }
>>>>>>> ff64e01 (Se pegan varios)
                    }
                }
            }
        }

    }
}
