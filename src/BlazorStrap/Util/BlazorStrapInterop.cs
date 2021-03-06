﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorStrap.Util
{
    public class BlazorStrapInterop
    {
        public static Func<Task> OnEscapeEvent { get; set; }

        public static Func<string, Task> OnAnimationEndEvent { get; set; }
        public static Func<string, string, Task> OnAddClassEvent { get; set; }
        protected IJSRuntime JSRuntime { get; }

        public BlazorStrapInterop(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }
        [JSInvokable]
        public static Task OnEscape()
        {
            OnEscapeEvent?.Invoke();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Set Collapse offset height
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ValueTask<bool> SetOffsetHeight(ElementReference el, bool show)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.collapsingElement", el, show);
        }

        /// <summary>
        /// Clear Collapse offset height
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ValueTask<bool> ClearOffsetHeight(ElementReference el)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.collapsingElementEnd", el);
        }
        /// <summary>
        /// Use for animated classes only. Blazor can not track classes added this way.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Classname"></param>
        /// <returns></returns>
        public ValueTask<bool> AddClass(ElementReference el, string Classname)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.addClass", el, Classname);
        }

        /// <summary>
        /// Use for animated classes only. Blazor can not track classes added this way.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Classname"></param>
        /// <returns></returns>
        public ValueTask<bool> AddBodyClass(string Classname)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.addBodyClass", Classname);
        }
        public ValueTask<bool> RemoveBodyClass(string Classname)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.removeBodyClass", Classname);
        }
        /// <summary>
        /// Primary use is with modals when the scroll bar is hidden
        /// </summary>
        /// <param name="padding"></param>
        /// <returns></returns>
        public ValueTask<bool> ChangeBodyPaddingRight(string padding)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.changeBodyPaddingRight", padding);
        }

        public ValueTask<string> ModalEscapeKey()
        {
            return JSRuntime.InvokeAsync<string>("blazorStrap.modelEscape");
        }
        public ValueTask<bool> Log(string message)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.log", message);
        }

        public ValueTask<bool> Popper(string target, string popper, ElementReference arrow, string placement)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.popper", target, popper, arrow, placement);
        }

        public ValueTask<bool> Tooltip(string target, ElementReference tooltip, ElementReference arrow, string placement)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.tooltip", target, tooltip, arrow, placement);
        }

        public ValueTask<object> FocusElement(ElementReference el)
        {
            return JSRuntime.InvokeAsync<object>("blazorStrap.focusElement", el);
        }

        public ValueTask<bool> SetBootstrapCss(string theme, string version)
        {
            return JSRuntime.InvokeAsync<bool>("blazorStrap.setBootstrapCss", theme, version);
        }

        [Obsolete("SetBootstrapCSS is obsolete and will be removed in a future version of BlazorStrap. Please use SetBootstrapCss instead.", false)]
        public ValueTask<bool> SetBootstrapCSS(string theme, string version) => SetBootstrapCss(theme, version);
    }

    public class StringReturn
    {
        public string Result { get; set; }
    }
}