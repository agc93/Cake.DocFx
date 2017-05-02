﻿using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DocFx.Helper;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains functionality related to <see href="http://dotnet.github.io/docfx">DocFx</see>.
    /// </summary>
    [CakeAliasCategory("DocFx")]
    public static class DocFxAliases
    {
        /// <summary>
        /// Builds DocFx API metadata and markdown files.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <example>
        /// <code>
        /// DocFx();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        public static void DocFx(this ICakeContext context)
            => context.DocFx(null, null);

        /// <summary>
        /// Builds markdown and API documentation using DocFx.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The path to the docfx.json config file.</param>
        /// <example>
        /// <code>
        /// DocFx("./docs/docfx.json");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        public static void DocFx(this ICakeContext context, FilePath configFile)
            => context.DocFx(configFile, null);

        /// <summary>
        /// Builds markdown and API documentation using DocFx, with the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The DocFx settings.</param>
        /// <example>
        /// <code>
        /// DocFx(new DocFxSettings()
        /// {
        ///     OutputPath = "./artifacts/docs"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        public static void DocFx(this ICakeContext context, DocFxSettings settings)
            => context.DocFx(null, settings);

        /// <summary>
        /// Builds markdown and API documentation using DocFx, with the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The path to the docfx.json config file.</param>
        /// <param name="settings">The DocFx settings.</param>
        /// <example>
        /// <code>
        /// DocFx("./docs/docfx.json", new DocFxSettings()
        /// {
        ///     OutputPath = "./artifacts/docs"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        public static void DocFx(this ICakeContext context, FilePath configFile, DocFxSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxSettings();

            var runner = new DocFxRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(configFile, settings);
        }
    }
}