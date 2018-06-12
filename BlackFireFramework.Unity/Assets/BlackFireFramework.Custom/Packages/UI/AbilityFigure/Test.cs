using Lyz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lyz
{
    public class Test : MonoBehaviour
    {
        AbilityFigure abilityFigure;
        private void Start()
        {
            abilityFigure = this.GetComponent<AbilityFigure>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                abilityFigure.AddDotFunc();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {

            }
        }

    }
}