using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ServiceLocator
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, IService> _rootServices = new Dictionary<Type, IService>();
        private static Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        public static void RegisterRoot<T> (T service) where T : IService
        {
            var type = typeof (T);

            _rootServices.TryAdd(type, service);
        }

        public static void Register<T>(T service) where T : IService
        {
            var type = typeof(T);

            _services.TryAdd(type, service);
        }

        public static T Get<T>() where T : class, IService
        {
            var type = typeof(T);

            if (_rootServices.TryGetValue(type, out var rootServices))
            {
                return (T)rootServices;
            }
            if (_services.TryGetValue(type, out var services))
            {
                return (T)services;
            }
            return null;
        }

        public static void CleanServices()
        {
            _services.Clear();
        }
    }
}