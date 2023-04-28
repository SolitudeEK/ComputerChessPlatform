import google_protobuf_empty_pb from 'google-protobuf/google/protobuf/empty_pb.js';
const { Name } = require('../proto/output/Management_pb.js');
const { ManagementGrpcClient } = require('../proto/output/Management_grpc_web_pb.js');

class Management {
    static Do() {
        var client = new ManagementGrpcClient('http://localhost:5001');
        var request = new google_protobuf_empty_pb.Empty();

        /*client.getEnginesToApprove(request, {}, (err, response) => {
          console.log(response.getMessage());
          return "Asd";
          });*/
        var stream = client.getEnginesToApprove(request);
        stream.on('data', function(response) {
            console.log(response.getName());
        });
        stream.on('status', function(status) {
            //console.log(status.code);
            //console.log(status.details);
            //console.log(status.metadata);
        });
        stream.on('end', function(end) {
            // stream end signal
          stream.cancel()
        });
    }
}
export default Management;