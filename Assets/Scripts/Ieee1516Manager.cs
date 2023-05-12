using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Ieee1516
{
    public class Ieee1516Manager : MonoBehaviour
    {
        public static Ieee1516Manager Instance => _instance;

        private static Ieee1516Manager _instance;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            Singleton();
            RegisterCallbacks();
            Connect();
        }

        private void OnDestroy()
        {
            UnregisterCallbacks();
        }

        private void Singleton()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(_instance.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        private void Connect()
        {
            var s = new StringBuilder(100);
            OpenRti.Connect(s, s.Length);
            Debug.Log("IEEE1516: " + s);
        }

        private void RegisterCallbacks()
        {
            OpenRti.RegisterDebugCallback(DebugCallbackLogger);
            OpenRti.RegisterConnectionLostCallback(ConnectionLost);
            OpenRti.RegisterReportFederationExecutionsCallback(ReportFederationExecutions);
            OpenRti.RegisterSynchronizationPointRegistrationSucceededCallback(
                SynchronizationPointRegistrationSucceeded);
            OpenRti.RegisterSynchronizationPointRegistrationFailedCallback(SynchronizationPointRegistrationFailed);
            OpenRti.RegisterAnnounceSynchronizationPointCallback(AnnounceSynchronizationPoint);
            OpenRti.RegisterFederationSynchronizedCallback(FederationSynchronized);
        }

        private void UnregisterCallbacks()
        {
            OpenRti.RegisterDebugCallback(null);
            OpenRti.RegisterConnectionLostCallback(null);
            OpenRti.RegisterReportFederationExecutionsCallback(null);
            OpenRti.RegisterSynchronizationPointRegistrationSucceededCallback(null);
            OpenRti.RegisterSynchronizationPointRegistrationFailedCallback(null);
            OpenRti.RegisterAnnounceSynchronizationPointCallback(null);
            OpenRti.RegisterFederationSynchronizedCallback(null);
        }

        private void DebugCallbackLogger(IntPtr str, int color, int size)
        {
            var message = Marshal.PtrToStringAnsi(str, size);
            Debug.Log("DebugCallbackLogger: " + message);
        }

        private void ConnectionLost(IntPtr str, int size)
        {
            var message = Marshal.PtrToStringAnsi(str, size);
            Debug.Log("ConnectionLost: " + message);
        }

        private void ReportFederationExecutions(IntPtr str1, IntPtr str2, int size1, int size2)
        {
            var message1 = Marshal.PtrToStringAnsi(str1);
            var message2 = Marshal.PtrToStringAnsi(str2);
            Debug.Log("ReportFederationExecutions: " + message1 + " : " + message2);
        }

        private void SynchronizationPointRegistrationSucceeded(IntPtr str, int size)
        {
            var message = Marshal.PtrToStringAnsi(str, size);
            Debug.Log("SynchronizationPointRegistrationSucceeded: " + message);
        }

        private void SynchronizationPointRegistrationFailed(IntPtr str1, IntPtr str2, int size1, int size2)
        {
            var message1 = Marshal.PtrToStringAnsi(str1, size1);
            var message2 = Marshal.PtrToStringAnsi(str2, size2);
            Debug.Log("SynchronizationPointRegistrationFailed: " + message1 + " : " + message2);
        }

        private void AnnounceSynchronizationPoint(IntPtr str1, int size1)
        {
            var message = Marshal.PtrToStringAnsi(str1, size1);
            Debug.Log("AnnounceSynchronizationPoint :" + message);
        }

        private void FederationSynchronized(IntPtr str1, int size1)
        {
            var message = Marshal.PtrToStringAnsi(str1, size1);
            Debug.Log("FederationSynchronized: " + message);
        }
    }
}