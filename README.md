# fable-from-scratch

1. Created a fable project from scratch with `dotnet new console -lang F#`.
2. Then move `Program.fs` under `src` and adjust the `.fsproj` accordingly.
3. Install `paket` with `paket init`.
4. Then `paket convert-from-nuget` so we have paket and a lock file.
5. Add `Fable.Core` with `paket add Fable.Core`.
6. Add `<DotNetCliToolReference Include="dotnet-fable" Version="*" />` to get the dotnet fable CLI tool.
7. Use `npm init` to generate a `package.json`.  Then add `babel`, `webpack`, and `fable-loader` dependencies.  
8. Add `project.json` with a build step `webpack -p`.
9. Add `webpack.config.js` to compile it all for `es2015` so it can run directly on node.
10. Run `npm install` to install all packages.

With all that completed, you can build with `dotnet fable npm-build` and then run with `node public/bundle.js`.

All sorts of [JS interop](https://medium.com/@zaid.naom/f-interop-with-javascript-in-fable-the-complete-guide-ccc5b896a59f)
can be performed to integrate with the node ecosystem.