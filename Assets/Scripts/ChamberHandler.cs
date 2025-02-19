using System;
using UnityEngine;
using System.Collections.Generic;

public class ChamberHandler : MonoBehaviour
{
    Queue<ChamberBrain> _selectedChambers = new Queue<ChamberBrain>();
    private void Update() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) 
        {
            if(hit.collider.TryGetComponent(out ChamberBrain chamberBrain)) {
                if(Input.GetMouseButtonDown(0)) {
                    if(!Input.GetKey(KeyCode.LeftShift)){
                        int nChambers = _selectedChambers.Count;
                        for(int i = 0; i < nChambers; ++i) 
                        {
                            _selectedChambers.Dequeue().Deselect();
                        }
                    }
                    _selectedChambers.Enqueue(chamberBrain);
                    chamberBrain.Select();
                }
            }
            else if(hit.collider.TryGetComponent(out HealthHandler healthHandler)) {
                if(Input.GetMouseButtonDown(0)) {
                    int nChambers = _selectedChambers.Count;
                    for(int i = 0; i < nChambers; ++i){
                        ChamberBrain a_chamber = _selectedChambers.Dequeue();
                        if(a_chamber != null) {
                            a_chamber.SetTarget(healthHandler);
                            a_chamber.Deselect();
                        }
                    }
                }
            }
            else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor")) {
                if(Input.GetMouseButtonDown(0)) {
                    int nChambers = _selectedChambers.Count;
                    for(int i = 0; i < nChambers; ++i){
                        ChamberBrain a_chamber = _selectedChambers.Dequeue();
                        if(a_chamber != null) {
                            a_chamber.GotoPosition(hit.point);
                            a_chamber.Deselect();
                        }
                    }
            }
        }

        }
    }
}