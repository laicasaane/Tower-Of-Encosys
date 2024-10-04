using System;
using Module.Core.Extended.Mvvm.ViewBinding.Unity;
using Module.Core.Mvvm.ViewBinding;
using UnityEngine;

namespace Module.Core.Extended.Mvvm.ViewBinding.Binders.Unity.Physics3D
{
    [Serializable]
    [Label("Box Collider", "Physics 3D")]
    public sealed partial class BoxColliderBinder : MonoBinder<BoxCollider>
    {
    }

    [Serializable]
    [Label("Center", "Box Collider")]
    public sealed partial class BoxColliderBindingCenter : MonoBindingProperty<BoxCollider>, IBinder
    {
        [BindingProperty]
        [field: HideInInspector]
        private void SetCenter(Vector3 value)
        {
            var targets = Targets;
            var length = targets.Length;

            for (var i = 0; i < length; i++)
            {
                targets[i].center = value;
            }
        }
    }

    [Serializable]
    [Label("Size", "Box Collider")]
    public sealed partial class BoxColliderBindingSize : MonoBindingProperty<BoxCollider>, IBinder
    {
        [BindingProperty]
        [field: HideInInspector]
        private void SetSize(Vector3 value)
        {
            var targets = Targets;
            var length = targets.Length;

            for (var i = 0; i < length; i++)
            {
                targets[i].size = value;
            }
        }
    }

    [Serializable]
    [Label("Is Trigger", "Box Collider")]
    public sealed partial class BoxColliderBindingIsTrigger : MonoBindingProperty<BoxCollider>, IBinder
    {
        [BindingProperty]
        [field: HideInInspector]
        private void SetIsTrigger(bool value)
        {
            var targets = Targets;
            var length = targets.Length;

            for (var i = 0; i < length; i++)
            {
                targets[i].isTrigger = value;
            }
        }
    }
}
