using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UPM.States;

namespace UPM.Editor {
    [InitializeOnLoad]
    public static class UPMAssemblyUtil {
        public static readonly List<StateData> KnownPossibleStates = new List<StateData>();


        private static readonly List<Assembly> KnownAssemblies = new List<Assembly>();

        private static void Reload() {
            KnownAssemblies.Clear();
            KnownPossibleStates.Clear();
        }

        static UPMAssemblyUtil() {
            LoadAssemblies();
            AppDomain.CurrentDomain.AssemblyLoad += OnAssemblyLoaded;
        }

        private static void LoadAssemblies() {
            Reload();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                RegisterAssembly(assembly);
            }
        }

        private static void OnAssemblyLoaded(object sender, AssemblyLoadEventArgs args) {
            RegisterAssembly(args.LoadedAssembly);
        }

        private static void RegisterAssembly(Assembly assembly) {
            KnownAssemblies.Add(assembly);
            var target = typeof(State);
            foreach (var type in assembly.GetTypes()) {
                if (target != type && target.IsAssignableFrom(type) && KnownPossibleStates.All(data => data.Type != type)) {
                    KnownPossibleStates.Add(new StateData(type));
                }
            }
        }

        public static IEnumerable<Type> GetAllTypesOf<T>() {
            var target = typeof(T);
            foreach (var assembly in KnownAssemblies) {
                foreach (var type in assembly.GetTypes()) {
                    if (target.IsAssignableFrom(type)) {
                        yield return type;
                    }
                }
            }
        }
    }
}