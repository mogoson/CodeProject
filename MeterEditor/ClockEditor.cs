/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PointerClockEditor.cs
 *  Description  :  Editor for PointerClock component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Meter;
using UnityEditor;

namespace MGS.MeterEditor
{
    [CustomEditor(typeof(PointerClock), true)]
    [CanEditMultipleObjects]
    public class ClockEditor : PointerMeterEditor
    {
        #region Field and Property 
        protected new PointerClock Target { get { return target as PointerClock; } }
        #endregion

        #region Protected Method
        protected override void OnSceneGUI()
        {
            DrawPointer(Target.pointer.hour);
            DrawPointer(Target.pointer.minute);
            DrawPointer(Target.pointer.second);
        }
        #endregion
    }
}