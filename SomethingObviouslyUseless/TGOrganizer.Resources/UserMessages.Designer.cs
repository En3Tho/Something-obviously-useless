﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TGOrganizer.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class UserMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UserMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TGOrganizer.Resources.UserMessages", typeof(UserMessages).Assembly);
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
        ///   Looks up a localized string similar to Please fill the body of task with data: message, photos, sounds and press &quot;Next&quot; button or enter /next command. To cancel operation please press &quot;Cancel&quot; button or use /cancel command. First text message will be used as a name for the task and should have length of 50 characters max..
        /// </summary>
        internal static string TaskCreateBodyDescription {
            get {
                return ResourceManager.GetString("TaskCreateBodyDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Now pick or skip recurrency period either via recurrency time picker or in &quot;HH.MM&quot; 24 hrs format. To skip either press &quot;Skip&quot; button or enter &quot;/skip&quot; command..
        /// </summary>
        internal static string TaskSetConcurrencyPeriodDescription {
            get {
                return ResourceManager.GetString("TaskSetConcurrencyPeriodDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pick a date for your task either with calendar buttons or via text message of &quot;YYYY.MM.DD&quot; format..
        /// </summary>
        internal static string TaskSetDateDescription {
            get {
                return ResourceManager.GetString("TaskSetDateDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Now pick a time either with time picker or via text message of &quot;HH.MM&quot; 24 hrs format..
        /// </summary>
        internal static string TaskSetTimeDescription {
            get {
                return ResourceManager.GetString("TaskSetTimeDescription", resourceCulture);
            }
        }
    }
}
