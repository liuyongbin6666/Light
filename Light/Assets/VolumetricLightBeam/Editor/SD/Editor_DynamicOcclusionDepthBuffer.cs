﻿#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using VolumetricLightBeam.Scripts;
using VolumetricLightBeam.Scripts.SD;

namespace VLB
{
    [CustomEditor(typeof(DynamicOcclusionDepthBuffer))]
    [CanEditMultipleObjects]
    public class Editor_DynamicOcclusionDepthBuffer : Editor_DynamicOcclusionAbstractBase<DynamicOcclusionDepthBuffer>
    {
        SerializedProperty depthMapResolution = null;
        SerializedProperty layerMask = null;
        SerializedProperty useOcclusionCulling = null;
        SerializedProperty fadeDistanceToSurface = null;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (m_Targets.HasAtLeastOneTargetWith((DynamicOcclusionDepthBuffer comp) => { return comp.GetComponent<VolumetricLightBeamSD>().dimensions == Dimensions.Dim2D; }))
            {
                EditorGUILayout.HelpBox(EditorStrings.DynOcclusion.HelpDepthBufferAndBeam2D, MessageType.Warning);
            }

            if (FoldableHeader.Begin(this, EditorStrings.DynOcclusion.HeaderCamera))
            {
                EditorGUILayout.PropertyField(layerMask, EditorStrings.DynOcclusion.LayerMask);

                if(VolumetricLightBeam.Scripts.Config.Instance.geometryOverrideLayer == false)
                {
                    EditorGUILayout.HelpBox(EditorStrings.DynOcclusion.HelpOverrideLayer, MessageType.Warning);
                }
                else if (m_Targets.HasAtLeastOneTargetWith((DynamicOcclusionDepthBuffer comp) => { return comp.HasLayerMaskIssues(); }))
                {
                    EditorGUILayout.HelpBox(EditorStrings.DynOcclusion.HelpLayerMaskIssues, MessageType.Warning);
                }

                EditorGUILayout.PropertyField(useOcclusionCulling, EditorStrings.DynOcclusion.DepthBufferOcclusionCulling);
                EditorGUILayout.PropertyField(depthMapResolution, EditorStrings.DynOcclusion.DepthBufferDepthMapResolution);
            }
            FoldableHeader.End();

            if (FoldableHeader.Begin(this, EditorStrings.DynOcclusion.HeaderOccluderSurface))
            {
                EditorGUILayout.PropertyField(fadeDistanceToSurface, EditorStrings.DynOcclusion.FadeDistanceToSurface);
            }
            FoldableHeader.End();

            DisplayCommonInspector();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
