using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeUtils
{
    public class MonoUpdater : MonoBehaviour
    {
        // 初始化方式，注释掉是因为选择在使用时才初始（Add方法中初始）
        // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void RuntimeInit()
        {
            if (instance != null)
                return;

            instance = new GameObject { name = "[Mono Updater]" };
            instance.AddComponent<MonoUpdater>();
            DontDestroyOnLoad(instance);
            allUpdateFunc = new List<UpdateFunction>();
        }

        // track all update method
        static List<UpdateFunction> allUpdateFunc;
        static GameObject instance;

        void Update()
        {
            foreach (var f in allUpdateFunc)
            {
                f.Update();
            }
        }

        public static UpdateFunction Add(Action updateFunc, bool active = true)
        {
            RuntimeInit();
            UpdateFunction func = new UpdateFunction(updateFunc, active);
            allUpdateFunc.Add(func);
            return func;
        }

        public static void Remove(UpdateFunction func)
        {
            allUpdateFunc.Remove(func);
        }

        public class UpdateFunction
        {
            Action updateFunc;
            bool active;

            public UpdateFunction(Action updateFunc, bool active)
            {
                this.updateFunc = updateFunc;
                this.active = active;
            }

            public void Update()
            {
                if (!active) return;
                updateFunc();
            }
        }
    }
}
