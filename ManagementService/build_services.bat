dotnet restore Host/Host.csproj

dotnet publish Host/Host.csproj -c Release-Linux -r linux-x64 --output /bin/Release

docker build -f .\DockerfileM -t management .

REM docker run -d -p 5001:5001 --name management management

pause