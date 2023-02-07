using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityTools
{
    public static class Tools
    {
        public static bool InvokeIfNotNull<T>(Collider2D contaiter, Action<T> handler)
        {
            if (contaiter.GetComponent<T>() != null)
            {
                handler?.Invoke(
                    contaiter.GetComponent<T>()
                    );

                return true;
            }

            return false;
        }

        public static bool InvokeIfNotNullInParent<T>(Collider contaiter, Action<T> handler)
        {
            if (contaiter.GetComponentInParent<T>() != null)
            {
                handler?.Invoke(
                    contaiter.GetComponentInParent<T>()
                    );

                return true;
            }

            return false;
        }

        public static bool InvokeIfNotNull<T>(Collision collision, Action<T> handler)
        {
            var container = collision.collider;
            if (container.GetComponent<T>() != null)
            {
                handler?.Invoke(
                    container.GetComponent<T>()
                    );

                return true;
            }

            return false;
        }

        public static bool InvokeIfNotNull<T>(Collider container, Action<T> handler)
        {
            if (container.GetComponent<T>() != null)
            {
                handler?.Invoke(
                    container.GetComponent<T>()
                    );

                return true;
            }

            return false;
        }

        public static bool InvokeIfNotNull<T>(Collider2D container, params Action[] handlers)
        {
            if (container.GetComponent<T>() != null)
            {
                foreach (var handler in handlers)
                    handler?.Invoke();

                return true;
            }

            return false;
        }

        public static bool InvokeIfNotNull<T>(Collider container, params Action[] handlers)
        {
            if (container.GetComponent<T>() != null)
            {
                foreach (var handler in handlers)
                    handler?.Invoke();

                return true;
            }

            return false;
        }

        public static void InvokeWithSameArgs<T>(T arg, params Action<T>[] actions)
        {
            foreach (var action in actions)
                action?.Invoke(arg);
        }

        public static void InvokeWithChance(int percentChance, params Action[] actions)
        {
            var random = Random.Range(0, 101);
            if (random <= percentChance)
                foreach (var action in actions)
                    action?.Invoke();
        }

        public static Material[] GetAllMaterials(GameObject gameObject)
        {
            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
            var materials = new List<Material>();
            foreach (var renderer in renderers)
            {
                materials.Add(renderer.material);
            }

            return materials.ToArray();
        }
    }
}