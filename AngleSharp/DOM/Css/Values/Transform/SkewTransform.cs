﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using System;

    /// <summary>
    /// Represents the skew transformation.
    /// </summary>
    sealed class SkewTransform : ITransform
    {
        readonly Angle _alpha;
        readonly Angle _beta;

        internal SkewTransform(Angle alpha, Angle beta)
        {
            _alpha = alpha;
            _beta = beta;
        }

        /// <summary>
        /// Computes the matrix for the given transformation.
        /// </summary>
        /// <returns>The transformation matrix representation.</returns>
        public TransformMatrix ComputeMatrix()
        {
            var a = _alpha.Tan();
            var b = _beta.Tan();
            return new TransformMatrix(1f, a, 0f, b, 1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f);
        }

        CssValueType ICssValue.Type
        {
            get { return CssValueType.Primitive; }
        }

        String ICssValue.CssText
        {
            get { return FunctionNames.Build(FunctionNames.Skew, ((ICssValue)_alpha).CssText, ((ICssValue)_beta).CssText); }
        }
    }
}