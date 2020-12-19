using System;
using System.Collections.Generic;
using System.Linq;
using Omnius.Core.RocketPack.DefinitionCompiler.Models;

namespace Omnius.Core.RocketPack.DefinitionCompiler
{
    internal partial class CodeGenerator
    {
        private sealed class ServiceWriter
        {
            private readonly RocketPackDefinition _rootDefinition;
            private readonly IList<RocketPackDefinition> _externalDefinitions;
            private readonly string _accessLevel;

            public ServiceWriter(RocketPackDefinition rootDefinition, IEnumerable<RocketPackDefinition> externalDefinitions)
            {
                _rootDefinition = rootDefinition;
                _externalDefinitions = externalDefinitions.ToList();

                var accessLevelOption = _rootDefinition.Options.FirstOrDefault(n => n.Name == "csharp_access_level");
                _accessLevel = accessLevelOption?.Value as string ?? "public";
            }

            public void Write(CodeWriter b)
            {
                foreach (var serviceDefinition in _rootDefinition.Services)
                {
                    this.Write_Interface(b, serviceDefinition);
                    this.Write_ClientAndServerClass(b, serviceDefinition);
                }
            }

            private object? FindDefinition(CustomType customType)
            {
                foreach (var definition in new[] { _rootDefinition }.Union(_externalDefinitions))
                {
                    var enumDefinition = definition.Enums.FirstOrDefault(m => m.Name == customType.TypeName);
                    if (enumDefinition != null)
                    {
                        return enumDefinition;
                    }

                    var objectDefinition = definition.Objects.FirstOrDefault(m => m.Name == customType.TypeName);
                    if (objectDefinition != null)
                    {
                        return objectDefinition;
                    }
                }

                return null;
            }

            private void Write_ClientAndServerClass(CodeWriter b, ServiceDefinition serviceDefinition)
            {
                var className = serviceDefinition.Name;
                b.WriteLine($"{_accessLevel} class {className}");
                b.WriteLine("{");

                using (b.Indent())
                {
                    this.Write_ClientClass(b, serviceDefinition);
                    this.Write_ServerClass(b, serviceDefinition);
                }

                b.WriteLine("}");
            }

            private void Write_Interface(CodeWriter b, ServiceDefinition serviceDefinition)
            {
                b.WriteLine($"{_accessLevel} interface {serviceDefinition.CSharpInterfaceName}");
                b.WriteLine("{");

                using (b.Indent())
                {
                    foreach (var func in serviceDefinition.Elements)
                    {
                        if (func.InType is not null && func.OutType is not null)
                        {
                            if (this.FindDefinition(func.InType) is ObjectDefinition inTypeObjectDef
                                && this.FindDefinition(func.OutType) is ObjectDefinition outTypeObjectDef)
                            {
                                b.WriteLine($"{GenerateTypeFullName("ValueTask<>", outTypeObjectDef.CSharpFullName)} {func.CSharpFunctionName}({inTypeObjectDef.CSharpFullName} param, {GenerateTypeFullName("CancellationToken")} cancellationToken = default);");
                            }
                        }
                        else if (func.InType is null && func.OutType is not null)
                        {
                            if (this.FindDefinition(func.OutType) is ObjectDefinition outTypeObjectDef)
                            {
                                b.WriteLine($"{GenerateTypeFullName("ValueTask<>", outTypeObjectDef.CSharpFullName)} {func.CSharpFunctionName}({GenerateTypeFullName("CancellationToken")} cancellationToken = default);");
                            }
                        }
                        else if (func.InType is not null && func.OutType is null)
                        {
                            if (this.FindDefinition(func.InType) is ObjectDefinition inTypeObjectDef)
                            {
                                b.WriteLine($"{GenerateTypeFullName("ValueTask")} {func.CSharpFunctionName}({inTypeObjectDef.CSharpFullName} param, {GenerateTypeFullName("CancellationToken")} cancellationToken = default);");
                            }
                        }
                        else if (func.InType is null && func.OutType is null)
                        {
                            {
                                b.WriteLine($"{GenerateTypeFullName("ValueTask")} {func.CSharpFunctionName}({GenerateTypeFullName("CancellationToken")} cancellationToken = default);");
                            }
                        }
                    }
                }

                b.WriteLine("}");
            }

            private void Write_ClientClass(CodeWriter b, ServiceDefinition serviceDefinition)
            {
                var className = "Client";
                b.WriteLine($"{_accessLevel} class {className} : {GenerateTypeFullName("AsyncDisposableBase")}, {serviceDefinition.CSharpInterfaceFullName}");
                b.WriteLine("{");

                using (b.Indent())
                {
                    b.WriteLine($"private readonly {GenerateTypeFullName("IConnection")} _connection;");
                    b.WriteLine($"private readonly {GenerateTypeFullName("IBytesPool")} _bytesPool;");
                    b.WriteLine($"private readonly {GenerateTypeFullName("RocketPackRpc")} _rpc;");
                    b.WriteLine($"public {className}({GenerateTypeFullName("IConnection")} connection, {GenerateTypeFullName("IBytesPool")} bytesPool)");
                    b.WriteLine("{");

                    using (b.Indent())
                    {
                        b.WriteLine("_connection = connection;");
                        b.WriteLine("_bytesPool = bytesPool;");
                        b.WriteLine($"_rpc = new {GenerateTypeFullName("RocketPackRpc")}(_connection, _bytesPool);");
                    }

                    b.WriteLine("}");
                    b.WriteLine($"protected override async {GenerateTypeFullName("ValueTask")} OnDisposeAsync()");
                    b.WriteLine("{");

                    using (b.Indent())
                    {
                        b.WriteLine("await _rpc.DisposeAsync();");
                    }

                    b.WriteLine("}");

                    foreach (var (index, func) in serviceDefinition.Elements.Select((n, i) => (i + 1, n)))
                    {
                        if (func.InType is not null && func.OutType is not null)
                        {
                            if (this.FindDefinition(func.InType) is ObjectDefinition inTypeObjectDef
                                && this.FindDefinition(func.OutType) is ObjectDefinition outTypeObjectDef)
                            {
                                b.WriteLine($"public async {GenerateTypeFullName("ValueTask<>", outTypeObjectDef.CSharpFullName)} {func.CSharpFunctionName}({inTypeObjectDef.CSharpFullName} param, {GenerateTypeFullName("CancellationToken")} cancellationToken)");
                                b.WriteLine("{");

                                using (b.Indent())
                                {
                                    b.WriteLine($"using var stream = await _rpc.ConnectAsync({index}, cancellationToken);");
                                    b.WriteLine($"return await stream.CallFunctionAsync<{inTypeObjectDef.CSharpFullName}, {outTypeObjectDef.CSharpFullName}>(param, cancellationToken);");
                                }

                                b.WriteLine("}");
                            }
                        }
                        else if (func.InType is null && func.OutType is not null)
                        {
                            if (this.FindDefinition(func.OutType) is ObjectDefinition outTypeObjectDef)
                            {
                                b.WriteLine($"public async {GenerateTypeFullName("ValueTask<>", outTypeObjectDef.CSharpFullName)} {func.CSharpFunctionName}({GenerateTypeFullName("CancellationToken")} cancellationToken)");
                                b.WriteLine("{");

                                using (b.Indent())
                                {
                                    b.WriteLine($"using var stream = await _rpc.ConnectAsync({index}, cancellationToken);");
                                    b.WriteLine($"return await stream.CallFunctionAsync<{outTypeObjectDef.CSharpFullName}>(cancellationToken);");
                                }

                                b.WriteLine("}");
                            }
                        }
                        else if (func.InType is not null && func.OutType is null)
                        {
                            if (this.FindDefinition(func.InType) is ObjectDefinition inTypeObjectDef)
                            {
                                b.WriteLine($"public async {GenerateTypeFullName("ValueTask")} {func.CSharpFunctionName}({inTypeObjectDef.CSharpFullName} param, {GenerateTypeFullName("CancellationToken")} cancellationToken)");
                                b.WriteLine("{");

                                using (b.Indent())
                                {
                                    b.WriteLine($"using var stream = await _rpc.ConnectAsync({index}, cancellationToken);");
                                    b.WriteLine($"await stream.CallActionAsync<{inTypeObjectDef.CSharpFullName}>(param, cancellationToken);");
                                }

                                b.WriteLine("}");
                            }
                        }
                        else if (func.InType is null && func.OutType is null)
                        {
                            {
                                b.WriteLine($"public async {GenerateTypeFullName("ValueTask")} {func.CSharpFunctionName}({GenerateTypeFullName("CancellationToken")} cancellationToken)");
                                b.WriteLine("{");

                                using (b.Indent())
                                {
                                    b.WriteLine($"using var stream = await _rpc.ConnectAsync({index}, cancellationToken);");
                                    b.WriteLine($"await stream.CallActionAsync(cancellationToken);");
                                }

                                b.WriteLine("}");
                            }
                        }
                    }
                }

                b.WriteLine("}");
            }

            private void Write_ServerClass(CodeWriter b, ServiceDefinition serviceDefinition)
            {
                var className = "Server";
                b.WriteLine($"{_accessLevel} class {className} : {GenerateTypeFullName("AsyncDisposableBase")}");
                b.WriteLine("{");

                using (b.Indent())
                {
                    b.WriteLine($"private readonly {serviceDefinition.CSharpInterfaceFullName} _service;");
                    b.WriteLine($"private readonly {GenerateTypeFullName("IConnection")} _connection;");
                    b.WriteLine($"private readonly {GenerateTypeFullName("IBytesPool")} _bytesPool;");
                    b.WriteLine($"private readonly {GenerateTypeFullName("RocketPackRpc")} _rpc;");
                    b.WriteLine($"public {className}({serviceDefinition.CSharpInterfaceFullName} service, {GenerateTypeFullName("IConnection")} connection, {GenerateTypeFullName("IBytesPool")} bytesPool)");
                    b.WriteLine("{");

                    using (b.Indent())
                    {
                        b.WriteLine("_service = service;");
                        b.WriteLine("_connection = connection;");
                        b.WriteLine("_bytesPool = bytesPool;");
                        b.WriteLine($"_rpc = new {GenerateTypeFullName("RocketPackRpc")}(_connection, _bytesPool);");
                    }

                    b.WriteLine("}");
                    b.WriteLine($"protected override async {GenerateTypeFullName("ValueTask")} OnDisposeAsync()");
                    b.WriteLine("{");
                    using (b.Indent())
                    {
                        b.WriteLine("await _rpc.DisposeAsync();");
                    }

                    b.WriteLine("}");

                    b.WriteLine($"public async {GenerateTypeFullName("Task")} EventLoop({GenerateTypeFullName("CancellationToken")} cancellationToken = default)");
                    b.WriteLine("{");

                    using (b.Indent())
                    {
                        b.WriteLine("while (!cancellationToken.IsCancellationRequested)");
                        b.WriteLine("{");

                        using (b.Indent())
                        {
                            b.WriteLine("cancellationToken.ThrowIfCancellationRequested();");
                            b.WriteLine("using var stream = await _rpc.AcceptAsync(cancellationToken);");

                            b.WriteLine("switch (stream.CallId)");
                            b.WriteLine("{");

                            using (b.Indent())
                            {
                                foreach (var (index, func) in serviceDefinition.Elements.Select((n, i) => (i + 1, n)))
                                {
                                    b.WriteLine($"case {index}:");

                                    using (b.Indent())
                                    {
                                        b.WriteLine("{");
                                        if (func.InType is not null && func.OutType is not null)
                                        {
                                            if (this.FindDefinition(func.InType) is ObjectDefinition inTypeObjectDef
                                                && this.FindDefinition(func.OutType) is ObjectDefinition outTypeObjectDef)
                                            {
                                                using (b.Indent())
                                                {
                                                    b.WriteLine($"await stream.ListenFunctionAsync<{inTypeObjectDef.CSharpFullName}, {outTypeObjectDef.CSharpFullName}>(_service.{func.CSharpFunctionName}, cancellationToken);");
                                                }
                                            }
                                        }
                                        else if (func.InType is null && func.OutType is not null)
                                        {
                                            if (this.FindDefinition(func.OutType) is ObjectDefinition outTypeObjectDef)
                                            {
                                                using (b.Indent())
                                                {
                                                    b.WriteLine($"await stream.ListenFunctionAsync<{outTypeObjectDef.CSharpFullName}>(_service.{func.CSharpFunctionName}, cancellationToken);");
                                                }
                                            }
                                        }
                                        else if (func.InType is not null && func.OutType is null)
                                        {
                                            if (this.FindDefinition(func.InType) is ObjectDefinition inTypeObjectDef)
                                            {
                                                using (b.Indent())
                                                {
                                                    b.WriteLine($"await stream.ListenActionAsync<{inTypeObjectDef.CSharpFullName}>(_service.{func.CSharpFunctionName}, cancellationToken);");
                                                }
                                            }
                                        }
                                        else if (func.InType is null && func.OutType is null)
                                        {
                                            using (b.Indent())
                                            {
                                                b.WriteLine($"await stream.ListenActionAsync(_service.{func.CSharpFunctionName}, cancellationToken);");
                                            }
                                        }

                                        b.WriteLine("}");
                                        b.WriteLine("break;");
                                    }
                                }
                            }

                            b.WriteLine("}");
                        }

                        b.WriteLine("}");
                    }

                    b.WriteLine("}");
                }

                b.WriteLine("}");
            }
        }
    }
}
