using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace SimpleDImple
{
   
    public enum ActivationMode 
    {
        awake,
        start,
        onEnable,
        external
    }
    
    [Serializable]
    public class StandartActivator
    {
        [SerializeField]
        ActivationMode activationMode = ActivationMode.awake;

        public StandartActivator(ActivationMode activationMode)
        {
            this.activationMode = activationMode;
        }

        public bool TryActivateOnAwake(Action action = null)
        {
            return TryActivate(ActivationMode.awake, action);
        }        
        public bool TryActivateOnStart(Action action = null)
        {
            return TryActivate(ActivationMode.start, action);
        }        
        public bool TryActivateOnEnable(Action action = null)
        {
            return TryActivate(ActivationMode.onEnable, action);
        }        
        public bool TryActivateExternal(Action action = null)
        {
            return TryActivate(ActivationMode.external, action);
        }

        private bool TryActivate(ActivationMode targetMode, Action action)
        {
            if (targetMode == activationMode)
            {
                action?.Invoke();
                return true;
            }
            return false;
        }
    }
    public interface IActivatable
    {
        void Activate();
    }
    
    
        public abstract class InstallerBase : MonoBehaviour, IActivatable
        {
            [SerializeField]
            StandartActivator activator = new StandartActivator(ActivationMode.start);

            private void Awake()
            {
                activator.TryActivateOnAwake(InjectDependencies);
            }
            private void Start()
            {
                activator.TryActivateOnStart(InjectDependencies);
            }        
            private void OnEnable()
            {
                activator.TryActivateOnEnable(InjectDependencies);
            }
            public void Activate()
            {
                activator.TryActivateExternal();
            }
            protected void InjectDependencies()
            {
                var behaiviours = GetComponents<MonoBehaviour>().Where(x => x != this);
                foreach (var x in behaiviours)
                {
                    var injectMethods = x.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Where(x => x.GetCustomAttributes<InjectableAttribute>(false).Any());
                    foreach (var injectMethod in injectMethods)
                    {
                        var parametres = injectMethod.GetParameters();

                        object[] args = new object[parametres.Length];
                        for (int i = 0; i < parametres.Length; i++)
                        {
                            Type parameterType = parametres[i].ParameterType;
                            args[i] = GetInjectArg(parameterType);
                        }

                        injectMethod.Invoke(x, args);
                    }
                }
            }

            protected abstract object GetInjectArg(Type parameterType);
        }
    }
