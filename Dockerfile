FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src
COPY [".", "."]

# Find the first .csproj file and extract project name
RUN CSPROJ_FILE=$(find . -maxdepth 1 -name "*.csproj" | head -1) && \
    if [ -z "$CSPROJ_FILE" ]; then echo "No .csproj file found!" && exit 1; fi && \
    PROJECT_NAME=$(basename "$CSPROJ_FILE" .csproj) && \
    echo "Building project: $PROJECT_NAME" && \
    dotnet publish "$CSPROJ_FILE" \
        -c Release \
        -o /app/publish \
        --runtime linux-musl-x64 \
        --self-contained true \
        /p:PublishSingleFile=true && \
    mv "/app/publish/$PROJECT_NAME" /app/publish/app

FROM mcr.microsoft.com/dotnet/runtime-deps:9.0-alpine
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080
ENTRYPOINT ["./app"]