FROM mcr.microsoft.com/dotnet/runtime:10.0 AS runtime
WORKDIR /app

COPY out/ .

ENTRYPOINT ["dotnet", "dz3.dll"]