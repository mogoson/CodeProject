/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoEventTrigger.cs
 *  Description  :  Event trigger for UI behaviour.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/30/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MGS.UCommon.Event
{
    /// <summary>
    /// Event trigger for UI behaviour.
    /// </summary>
    [AddComponentMenu("MGS/UCommon/Event/MonoEventTrigger")]
    public class MonoEventTrigger : MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler,
        IPointerClickHandler, IBeginDragHandler, IInitializePotentialDragHandler, IDragHandler, IEndDragHandler,
        IDropHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler, ICancelHandler
    {
        #region Field and Property
        /// <summary>
        /// On pointer enter event.
        /// </summary>
        public GenericEvent<PointerEventData> onPointerEnter { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On pointer exit event.
        /// </summary>
        public GenericEvent<PointerEventData> onPointerExit { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On pointer down event.
        /// </summary>
        public GenericEvent<PointerEventData> onPointerDown { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On pointer up event.
        /// </summary>
        public GenericEvent<PointerEventData> onPointerUp { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On pointer click event.
        /// </summary>
        public GenericEvent<PointerEventData> onPointerClick { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On begin drag event.
        /// </summary>
        public GenericEvent<PointerEventData> onBeginDrag { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On initialize potential drag event.
        /// </summary>
        public GenericEvent<PointerEventData> onInitializePotentialDrag { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On drag event.
        /// </summary>
        public GenericEvent<PointerEventData> onDrag { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On end drag event.
        /// </summary>
        public GenericEvent<PointerEventData> onEndDrag { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On drop event.
        /// </summary>
        public GenericEvent<PointerEventData> onDrop { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On scroll event.
        /// </summary>
        public GenericEvent<PointerEventData> onScroll { get; } = new GenericEvent<PointerEventData>();

        /// <summary>
        /// On update selected event.
        /// </summary>
        public GenericEvent<BaseEventData> onUpdateSelected { get; } = new GenericEvent<BaseEventData>();

        /// <summary>
        /// On select event.
        /// </summary>
        public GenericEvent<BaseEventData> onSelect { get; } = new GenericEvent<BaseEventData>();

        /// <summary>
        /// On deselect event.
        /// </summary>
        public GenericEvent<BaseEventData> onDeselect { get; } = new GenericEvent<BaseEventData>();

        /// <summary>
        /// On move event.
        /// </summary>
        public GenericEvent<AxisEventData> onMove { get; } = new GenericEvent<AxisEventData>();

        /// <summary>
        /// On submit event.
        /// </summary>
        public GenericEvent<BaseEventData> onSubmit { get; } = new GenericEvent<BaseEventData>();

        /// <summary>
        /// On cancel event.
        /// </summary>
        public GenericEvent<BaseEventData> onCancel { get; } = new GenericEvent<BaseEventData>();
        #endregion

        #region Public Method
        /// <summary>
        /// On pointer enter.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            onPointerEnter.Invoke(eventData);
        }

        /// <summary>
        /// On pointer exit.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnPointerExit(PointerEventData eventData)
        {
            onPointerExit.Invoke(eventData);
        }

        /// <summary>
        /// On pointer down.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnPointerDown(PointerEventData eventData)
        {
            onPointerDown.Invoke(eventData);
        }

        /// <summary>
        /// On pointer up.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnPointerUp(PointerEventData eventData)
        {
            onPointerUp.Invoke(eventData);
        }

        /// <summary>
        /// On pointer click.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            onPointerClick.Invoke(eventData);
        }

        /// <summary>
        /// On begin drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            onBeginDrag.Invoke(eventData);
        }

        /// <summary>
        /// On initialize potential drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            onInitializePotentialDrag.Invoke(eventData);
        }

        /// <summary>
        /// On drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnDrag(PointerEventData eventData)
        {
            onDrag.Invoke(eventData);
        }

        /// <summary>
        /// On end drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnEndDrag(PointerEventData eventData)
        {
            onEndDrag.Invoke(eventData);
        }

        /// <summary>
        /// On drop.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnDrop(PointerEventData eventData)
        {
            onDrop.Invoke(eventData);
        }

        /// <summary>
        /// On scroll.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnScroll(PointerEventData eventData)
        {
            onScroll.Invoke(eventData);
        }

        /// <summary>
        /// On update selected.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnUpdateSelected(BaseEventData eventData)
        {
            onUpdateSelected.Invoke(eventData);
        }

        /// <summary>
        /// On select.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnSelect(BaseEventData eventData)
        {
            onSelect.Invoke(eventData);
        }

        /// <summary>
        /// On deselect.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnDeselect(BaseEventData eventData)
        {
            onDeselect.Invoke(eventData);
        }

        /// <summary>
        /// On move.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnMove(AxisEventData eventData)
        {
            onMove.Invoke(eventData);
        }

        /// <summary>
        /// On submit.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnSubmit(BaseEventData eventData)
        {
            onSubmit.Invoke(eventData);
        }

        /// <summary>
        /// On cancel.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnCancel(BaseEventData eventData)
        {
            onCancel.Invoke(eventData);
        }
        #endregion
    }
}