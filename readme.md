# dapr grpc server
dapr run -a eh-grpc-server -p 5000 -P grpc -- dotnet run
dapr run --app-id eh-grpc-server --app-port 5000 --app-protocol grpc dotnet run

# dapr grpc client
dapr run -a eh-grpc-client -P grpc -- dotnet run
dapr run --app-id eh-grpc-client --app-protocol grpc dotnet run


#dapr api server
dapr run --app-id eh-api-server --app-port 4000 --dapr-http-port 4001 dotnet run

#dapr api client
dapr run --app-id eh-api-client -- dotnet run