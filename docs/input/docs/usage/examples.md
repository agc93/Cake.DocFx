# Build Script

To use DocFX in your Cake file simply import it and the DocFX tool. Then define a doc task.

```cake
#addin "Cake.DocFx"
#tool "docfx.console"

Task("doc").Does(() => DocFxBuild());
```

:::{.alert .alert-info}
**IMPORTANT** Do not forget to load '#tool "docfx.console"' at top of your Cake file. Otherwise, you can not run the `DocFx()` command.
:::

If the `docfx.json` file is anywhere else then the root directory you can pass in the location as parameter.

```cake
#addin "Cake.DocFx"
#tool "docfx.console"

Task("doc").Does(() => DocFxBuild("./docs/docfx.json"));
```

:::{.alert .alert-info}
**IMPORTANT** The `DocFx` command requires an existing `docfx.json` file. To bootstrap DocFX use `docfx init` or `./tools/docfx.console/tools/docfx.exe init`.
:::