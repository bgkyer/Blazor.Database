﻿/// =================================
/// Author: Shaun Curtis, Cold Elm
/// License: MIT
/// ==================================

namespace Blazor.SPA.Components
{
    /// <summary>
    /// ResultType Enum
    /// </summary>
    public enum ModalResultType { NoSet, OK, Cancel, Exit }

    /// <summary>
    /// Class to encapsulate the data returned by a Modal Dialog
    /// </summary>
    public class ModalResult
    {
        public ModalResultType ResultType { get; private set; } = ModalResultType.NoSet;

        public object Data { get; set; } = null;

        public static ModalResult OK() => new ModalResult() { ResultType = ModalResultType.OK };

        public static ModalResult Exit() => new ModalResult() { ResultType = ModalResultType.Exit };

        public static ModalResult Cancel() => new ModalResult() { ResultType = ModalResultType.Cancel };

        public static ModalResult OK(object data) => new ModalResult() { Data = data, ResultType = ModalResultType.OK };

        public static ModalResult Exit(object data) => new ModalResult() { Data = data, ResultType = ModalResultType.Exit };

        public static ModalResult Cancel(object data) => new ModalResult() { Data = data, ResultType = ModalResultType.Cancel };
    }
}
