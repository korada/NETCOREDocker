FROM microsoft/dotnet:2.1-sdk as build

COPY ./src/DockerDemo.Api/DockerDemo.Api.csproj /dockerdemo/src/DockerDemo.Api/DockerDemo.Api.csproj
COPY ./src/DockerDemo.UI/DockerDemo.UI.csproj /dockerdemo/src/DockerDemo.UI/DockerDemo.UI.csproj
COPY ./DockerDemo.sln /dockerdemo/DockerDemo.sln

RUN dotnet restore /dockerdemo/DockerDemo.sln

COPY ./ /dockerdemo

RUN dotnet publish -c Release -o /dockerdemo/out /dockerdemo/DockerDemo.sln
COPY ./entrypoint.sh /dockerdemo/out
RUN chmod +x /dockerdemo/out/entrypoint.sh
FROM microsoft/dotnet:2.1-aspnetcore-runtime

COPY --from=build /dockerdemo/out /dockerdemo

WORKDIR /dockerdemo

ENTRYPOINT ["./entrypoint.sh"]
CMD ["executable"]