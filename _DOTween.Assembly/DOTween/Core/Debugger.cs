﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/07/03 11:33
// 
// License Copyright (c) Daniele Giardini.
// This work is subject to the terms at http://dotween.demigiant.com/license.php

using UnityEngine;

#pragma warning disable 1591
namespace DG.Tweening.Core
{
    /// <summary>
    /// Public so it can be used by lose scripts related to DOTween (like DOTweenAnimation)
    /// </summary>
    public static class Debugger
    {
        // 0: errors only - 1: default - 2: verbose
        public static int logPriority { get { if (!DOTween.initialized) DOTween.Init(); return _logPriority; } }
        static int _logPriority;

        const string _LogPrefix = "<color=#0099bc><b>DOTWEEN ► </b></color>";

        public static void Log(object message)
        {
            message = _LogPrefix + message;
            if (DOTween.onWillLog != null && !DOTween.onWillLog(LogType.Log, message)) return;
            Debug.Log(message);
        }
        public static void LogWarning(object message)
        {
            message = _LogPrefix + message;
            if (DOTween.onWillLog != null && !DOTween.onWillLog(LogType.Warning, message)) return;
            Debug.LogWarning(message);
        }
        public static void LogError(object message)
        {
            message = _LogPrefix + message;
            if (DOTween.onWillLog != null && !DOTween.onWillLog(LogType.Error, message)) return;
            Debug.LogError(message);
        }

        public static void LogReport(object message)
        {
            message = string.Format("<color=#00B500FF>{0} REPORT ►</color> {1}", _LogPrefix, message);
            if (DOTween.onWillLog != null && !DOTween.onWillLog(LogType.Log, message)) return;
            Debug.Log(message);
        }

        public static void LogSafeModeReport(object message)
        {
            message = string.Format("<color=#ff7337>{0} SAFE MODE ►</color> {1}", _LogPrefix, message);
            if (DOTween.onWillLog != null && !DOTween.onWillLog(LogType.Log, message)) return;
            Debug.LogWarning(message);
        }

        public static void LogInvalidTween(Tween t)
        {
            LogWarning("This Tween has been killed and is now invalid");
        }

//        public static void LogNullTarget()
//        {
//            LogWarning("The target for this tween shortcut is null");
//        }

        public static void LogNestedTween(Tween t)
        {
            LogWarning("This Tween was added to a Sequence and can't be controlled directly");
        }

        public static void LogNullTween(Tween t)
        {
            LogWarning("Null Tween");
        }

        public static void LogNonPathTween(Tween t)
        {
            LogWarning("This Tween is not a path tween");
        }

        public static void LogMissingMaterialProperty(string propertyName)
        {
            LogWarning(string.Format("This material doesn't have a {0} property", propertyName));
        }
        public static void LogMissingMaterialProperty(int propertyId)
        {
            LogWarning(string.Format("This material doesn't have a {0} property ID", propertyId));
        }

        public static void LogRemoveActiveTweenError(string errorInfo)
        {
            LogWarning(string.Format("Error in RemoveActiveTween ({0}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.", errorInfo));
        }

        public static void LogAddActiveTweenError(string errorInfo)
        {
            LogWarning(string.Format("Error in AddActiveTween ({0}). It's been taken care of so no problems, but Daniele (DOTween's author) is trying to pinpoint it (it's very rare and he can't reproduce it) so it would be awesome if you could reproduce this log in a sample project and send it to him. Or even just write him the complete log that was generated by this message. Fixing this would make DOTween slightly faster. Thanks.", errorInfo));
        }

        public static void SetLogPriority(LogBehaviour logBehaviour)
        {
            switch (logBehaviour) {
            case LogBehaviour.Default:
                _logPriority = 1;
                break;
            case LogBehaviour.Verbose:
                _logPriority = 2;
                break;
            default:
                _logPriority = 0;
                break;
            }
        }
    }
}