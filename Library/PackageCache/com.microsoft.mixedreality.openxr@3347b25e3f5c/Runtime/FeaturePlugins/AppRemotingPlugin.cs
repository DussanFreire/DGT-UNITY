// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.Management;
using UnityEngine.XR.OpenXR;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.XR.OpenXR.Features;
#endif

namespace Microsoft.MixedReality.OpenXR.Remoting
{
#if UNITY_EDITOR
    [OpenXRFeature(UiName = "Holographic Remoting remote app",
        BuildTargetGroups = new[] { BuildTargetGroup.Standalone, BuildTargetGroup.WSA },
        Company = "Microsoft",
        Desc = "Feature to enable Holographic Remoting remote app.",
        DocumentationLink = "https://aka.ms/openxr-unity-app-remoting",
        OpenxrExtensionStrings = requestedExtensions,
        Category = FeatureCategory.Feature,
        Required = false,
        Priority = -100,    // hookup before other plugins so it affects json before GetProcAddr.
        FeatureId = featureId,
        Version = "1.1.2")]
#endif
    [NativeLibToken(NativeLibToken = NativeLibToken.Remoting)]
    internal class AppRemotingPlugin : OpenXRFeaturePlugin<AppRemotingPlugin>
    {
        internal const string featureId = "com.microsoft.openxr.feature.appremoting";
        private const string requestedExtensions = "XR_MSFT_holographic_remoting";

        private bool m_runtimeOverrideAttempted = false;

        // Unity might restart XR subsystem when remote runtime errors out.  Unity doesn't support skipping such restart yet.
        // A workaround is to remember such failure and skip next connect quickly to avoid blocking the UI thread.
        // When Unity supports skipping restart XR session, this flag can be removed and remoting connection can be stopped upon error.
        private bool m_skipNextConnection = false;

        private readonly bool m_appRemotingEnabled =
#if UNITY_EDITOR
            false;
#else
            true;
#endif
        protected override IntPtr HookGetInstanceProcAddr(IntPtr func)
        {
            if (m_appRemotingEnabled && !m_runtimeOverrideAttempted)
            {
                m_runtimeOverrideAttempted = true;
                if (!NativeLib.TryEnableRemotingOverride(nativeLibToken))
                {
                    Debug.LogError($"Failed to enable remoting runtime.");
                }
            }
            return base.HookGetInstanceProcAddr(func);
        }

        protected override void OnInstanceDestroy(ulong instance)
        {
            if (m_appRemotingEnabled && m_runtimeOverrideAttempted)
            {
                m_runtimeOverrideAttempted = false;
                NativeLib.ResetRemotingOverride(nativeLibToken);
            }
            base.OnInstanceDestroy(instance);
        }

        protected override void OnSystemChange(ulong systemId)
        {
            base.OnSystemChange(systemId);

            if (systemId != 0 && m_appRemotingEnabled)
            {
                if (m_skipNextConnection)
                {
                    m_skipNextConnection = false;
                    Debug.Log("Skip remote connection because previous connection was aborted.");
                    AppRemoting.Disconnect();
                }
                else
                {
                    NativeLib.ConnectRemoting(nativeLibToken, AppRemoting.Configuration);
                }
            }
        }

        protected override void OnSessionStateChange(int oldState, int newState)
        {
            if (m_appRemotingEnabled && (XrSessionState)newState == XrSessionState.LossPending)
            {
                Debug.LogError($"Cannot establish a connection to Holographic Remoting Player " +
                    $"on the target with IP Address {AppRemoting.Configuration.RemoteHostName}:{AppRemoting.Configuration.RemotePort}.");

                m_skipNextConnection = true;
            }
        }

#if UNITY_EDITOR
        protected override void GetValidationChecks(System.Collections.Generic.List<ValidationRule> results, BuildTargetGroup targetGroup)
        {
            AppRemotingValidator.GetValidationChecks(this, results, targetGroup);
        }
#endif
    }
}
