﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18331
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Windows.Core.Localization {
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
    internal class ImageMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ImageMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Windows.Core.Localization.ImageMessages", typeof(ImageMessages).Assembly);
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
        ///   Looks up a localized string similar to Die Datei ist mit {0} KB zu gross,.
        /// </summary>
        internal static string FileTooBig {
            get {
                return ResourceManager.GetString("FileTooBig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to die Grösse wird reduziert.
        /// </summary>
        internal static string ResizeAutomatically {
            get {
                return ResourceManager.GetString("ResizeAutomatically", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to bitte verkleinern Sie es.
        /// </summary>
        internal static string ResizeManually {
            get {
                return ResourceManager.GetString("ResizeManually", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bildformat unbekannt.
        /// </summary>
        internal static string UnkownImageFileFormat {
            get {
                return ResourceManager.GetString("UnkownImageFileFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Das Bildformat ist unbekannt oder wird nicht unterstützt..
        /// </summary>
        internal static string UnkownImageFileFormatMsg {
            get {
                return ResourceManager.GetString("UnkownImageFileFormatMsg", resourceCulture);
            }
        }
    }
}