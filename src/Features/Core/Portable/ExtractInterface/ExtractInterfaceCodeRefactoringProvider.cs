﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Composition;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis.Shared.Extensions;

namespace Microsoft.CodeAnalysis.ExtractInterface
{
    [ExportCodeRefactoringProvider(LanguageNames.CSharp, LanguageNames.VisualBasic,
        Name = PredefinedCodeRefactoringProviderNames.ExtractInterface), Shared]
    internal class ExtractInterfaceCodeRefactoringProvider : CodeRefactoringProvider
    {
        public sealed override async Task ComputeRefactoringsAsync(CodeRefactoringContext context)
        {
            var service = context.Document.GetLanguageService<AbstractExtractInterfaceService>();
            var actions = await service.GetExtractInterfaceCodeActionAsync(context.Document, context.Span, context.CancellationToken).ConfigureAwait(false);
            context.RegisterRefactorings(actions);
        }
    }
}