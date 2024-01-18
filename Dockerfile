FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

COPY ./bin/Debug/net6.0/ .

CMD ["dotnet", "SpnGF.dll"]