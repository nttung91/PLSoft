﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18331
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Windows.Core.Execution {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class PluginExecutorRes {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PluginExecutorRes() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Windows.Core.Execution.PluginExecutorRes", typeof(PluginExecutorRes).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ja.
        /// </summary>
        internal static string AcceptButtonText {
            get {
                return ResourceManager.GetString("AcceptButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nein.
        /// </summary>
        internal static string CancelButtonText {
            get {
                return ResourceManager.GetString("CancelButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zugriff nicht erlaubt.
        /// </summary>
        internal static string NoPermissionCaption {
            get {
                return ResourceManager.GetString("NoPermissionCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sie haben nicht das erforderliche Recht um dieses Programm auszuführen..
        /// </summary>
        internal static string NoPermissionMsg {
            get {
                return ResourceManager.GetString("NoPermissionMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Das Rechtesystem verweigert die Ausführung dieser Applikation. Für weitere Informationen wenden sie sich an den Administrator oder Helpdesk..
        /// </summary>
        internal static string SecurityProblem {
            get {
                return ResourceManager.GetString("SecurityProblem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dieses Programm steht nur noch heute zur Verfügung..
        /// </summary>
        internal static string ValidOnlyToday {
            get {
                return ResourceManager.GetString("ValidOnlyToday", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Für weitere Informationen wenden sie sich an den Administrator oder Helpdesk..
        /// </summary>
        internal static string ValidToAskSysAdmin {
            get {
                return ResourceManager.GetString("ValidToAskSysAdmin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dieses Programm steht nur noch {0} Tage zur Verfügung..
        /// </summary>
        internal static string ValidToHint {
            get {
                return ResourceManager.GetString("ValidToHint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Möchten Sie stattdessen das neue Programm starten?.
        /// </summary>
        internal static string ValidToStartReplacementPlugin {
            get {
                return ResourceManager.GetString("ValidToStartReplacementPlugin", resourceCulture);
            }
        }
    }
}
