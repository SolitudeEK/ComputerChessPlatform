dotnet restore Host/Host.csproj

dotnet publish Host/Host.csproj -c Release-Linux -r linux-x64 --output /bin/Release

docker build -f .\DockerfileEM -t engine_managment .

REM docker run -d -p 5000:5000 --name engine_managment engine_managment

pause