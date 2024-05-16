using System;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype4.Events {
   public abstract class EventChannelSO : ScriptableObject {
      internal UnityAction OnEventRaised = delegate { };

      internal virtual void RaiseEvent() {
         OnEventRaised?.Invoke();
      }
   }

   public abstract class EventChannelSO<T> : ScriptableObject {
      internal UnityAction<T> OnEventRaised = delegate { };

      internal virtual void RaiseEvent(T value) {
         OnEventRaised?.Invoke(value);
      }
   }

   public abstract class EventChannelSO<T0, T1> : ScriptableObject {
      internal UnityAction<T0, T1> OnEventRaised = delegate { };

      internal virtual void RaiseEvent(T0 t0, T1 t1) {
         OnEventRaised?.Invoke(t0, t1);
      }
   }

   public abstract class EventChannelSO<T0, T1, T2> : ScriptableObject {
      internal UnityAction<T0, T1, T2> OnEventRaised = delegate { };

      internal virtual void RaiseEvent(T0 t0, T1 t1, T2 t2) {
         OnEventRaised?.Invoke(t0, t1, t2);
      }
   }
}