using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Features.Volunteering
{
    public static class Singleton<T>
        where T : class
    {
        private static T s_Instance = null;
        private static object s_InstanceLock = new object();

        public static T Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_InstanceLock)
                    {
                        if (s_Instance == null)
                        {
                            Type typeOfT = typeof(T);

                            s_Instance = (T)typeOfT.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null).Invoke(null);
                        }
                    }
                }

                return s_Instance;
            }
        }
    }
}
