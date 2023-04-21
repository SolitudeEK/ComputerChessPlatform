using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Proto
{
    public class ManagementService : ManagementGrpc.ManagementGrpcBase
    {
        private IManagement management { get; set; }
        private readonly string path;
        public ManagementService(IManagement management, IConfiguration configuration)
        {
            this.management = management;
            path = configuration.GetSection("pathToSave").Value;
        }

        public override Task<Empty> UploadEngine(EngineRequest request, ServerCallContext context)
        {
            File.WriteAllText(path + request.FileName, request.Data.ToStringUtf8());
            management.UploadEngine(request.Name, path + request.FileName);
            return Task.Run(() => new Empty());
        }
        public override Task<Engine> DownloadEngine(Name request, ServerCallContext context)
            => Task.FromResult(new Engine
            {
                Name = request.Name_,
                Data = ByteString.CopyFromUtf8(File.ReadAllText(management.DownloadEngine(request.Name_)))
            });
        public override Task<Empty> ApproveEngine(Name request, ServerCallContext context)
        {
            management.ApproveEngine(request.Name_);
            return Task.Run(() => new Empty());
        }
        public override Task GetEnginesToApprove(Empty request, IServerStreamWriter<Name> responseStream, ServerCallContext context)
            => Task.Run(() => management.GetEngines().ForEach(engine =>  responseStream.WriteAsync(new Name { Name_ = engine }) ));
        
        
    }

}
